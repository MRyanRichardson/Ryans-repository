$(document).ready(function () {
    //load all items to populate products
    loadItems();
    $("#addDollar").click(function () {
        fnAddMoney(1.00);
    });
    $("#addQuarter").click(function () {
        fnAddMoney(.25);
    });
    $("#addDime").click(function () {
        fnAddMoney(.1);
    });
    $("#addNickel").click(function () {
        fnAddMoney(.05);
    });
    $("#changeReturn").click(function () {
        var amount = $("#txtTotal").val();
        var change = fnChangeReturn(amount);
        $("#txtChange").val(change);
        $("#txtTotal").val(0);
        $("#txtItem").val('');
        $('#txtMessage').val('');
    });
    // button that executes make purchase
    $("#makePurchase").click(function (event) {
        $.ajax({
            type: 'GET',
            //creating our URL for make purchase function
            url: 'http://localhost:8080/money/' + $("#txtTotal").val() + '/item/' + $("#txtItem").val(),
            data: '',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function (data, status) {
                //if successful call function and pass in the response data from our URL
                fnConvertOutput(data, status);
                $("#txtItem").val('');
                //clears all product items out
                clearItems();
                //reload items with correct quantity
                loadItems();
            },
            //if insufficient funds or sold out then a 422 status code is returned
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 422) {
                    fnConvertOutput(jqXHR.responseJSON, jqXHR.status);
                } else {
                    alert(errorThrown);
                }
            }
        });
    });
});
//sets the id of the clicked product
function fnSelectItem(id) {
    $("#txtItem").val(id);
    $("#txtChange").val("");
    $("#txtMessage").val("");
}
//calculates the amount entered and returns to our total $ box
function fnAddMoney(amount) {
    //had to parsefloat to be able to get only 2 after decimal
    var amt = amount + parseFloat($("#txtTotal").val());
    $("#txtTotal").val(Number.parseFloat(amt).toFixed(2));
    //clearing change message textboxes when client enters additional funds
    $("#txtChange").val("");
    $("#txtMessage").val("");
}
// returns the amount of change that the client will recieve in return
//only called when client clicks change return
//quarters = change /25
function fnChangeReturn(amount) {
    var quarters = 0;
    var dimes = 0;
    var nickels = 0;
    var rtnString = "";
    //parsefloat amount *100 to elimanate decimals for easier computation
    var change = parseFloat(amount) * 100;
    while (change > 24) {
        change -= 25;
        quarters++;
    }
    while (change > 9) {
        change -= 10;
        dimes++;
    }
    while (change > 4) {
        change -= 5;
        nickels++;
    }
    if (quarters > 0) {
        rtnString += quarters + " Quarters ";
    }
    if (dimes > 0) {
        rtnString += dimes + " Dimes ";
    }
    if (nickels > 0) {
        rtnString += nickels + " Nickels ";
    }
    return rtnString;
}
// convert outputs for our change return and returns message of thank you sold out or add more change
function fnConvertOutput(data, status) {
    if (status === "success") {
        var outputString = "";
        // setting total textbox to zero
        $("#txtTotal").val(0);
        //setting item textbox to empty
        $("#txtItem").empty();
        //creating string for the output of change in the change return textbox
        //user ternary to see if change is greater than zero if so output change
        outputString += data.quarters > 0 ? data.quarters + " Quarter(s) " : "";
        outputString += data.dimes > 0 ? data.dimes + " Dime(s) " : "";
        outputString += data.nickels > 0 ? data.nickels + " Nickel(s) " : "";
        $("#txtChange").val(outputString);
        $("#txtMessage").val("Thank You!!!");
    } else {
        //get message from data (SOLD OUT) or it can be (NOT ENOUGH MONEY).
        $("#txtMessage").val(data.message);
        $("#txtChange").val("");
    }
}
// function to clear all of the products
function clearItems() {
    $('#productBody').empty();
}
//Load all items and populate our product body
function loadItems() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        data: '',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (data, status) {
            //if successful call display items function and pass in our data and status
            displayItems(data, status);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
//Display all of the product items to the HTML (UI)
function displayItems(data) {
    var contentRows = $('#productBody');
    var count = 0;
    var row = "";
    //how many items are in productbody (9)
    var dataLength = data.length;
    row += '<div class="row">';
    $.each(data, function (index, item) {
        var id = item.id;
        var name = item.name;
        var price = item.price;
        var quantity = item.quantity;
        // count up to loop through all of the product ids
        count++;
        row += '<div class="col-sm-4 text-center" >';
        //used tab index to set focus to product div
        row += '        <div id="product" onclick="fnSelectItem(' + id + ')"  tabIndex="' + count + '">';
        //used inline css to style id to top left of column
        row += '            <p style="text-align:left ; padding-left:5px;">' + id + '</p>';
        row += '            <h3>' + name + '</h3>';
        row += '            <p>Price: $' + price + '</p>';
        row += '            <p>Quantity: ' + quantity + '</p>';
        row += '        </div>';
        row += '</div>';
        // if count is 3 start new row
        if (count % 3 === 0) {
            row += '</div>';
            //adding row to div ProductBody
            contentRows.append(row);
            if (count != dataLength) {
                //start a new row unless we are at the end of our datalength (9)
                row = '<div class="row">';
            }
        }
    });
}