$(document).ready(function () {



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
        $("#txtTotal").val("0");
        $("#txtItem").val("");
        $("#txtMessage").val("");

    });



    $("#makePurchase").click(function (event) {


        $.ajax({

            type: 'GET',
            //url: 'http://localhost:8080/money/{amount}/item/{id}',
            url: 'http://localhost:8080/money/' + $("#txtTotal").val() + '/item/' + $("#txtItem").val(),
            data: JSON.stringify({
                amount: $('#txtTotal').val(),
                id: $('#txtItem').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function (data, status) {
                fnConvertOutput(data, status);
                $("#txtItem").val('');
                clearItems();
                loadItems();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 422) {
                    fnConvertOutput(jqXHR.responseJSON, jqXHR.status);
                } else {
                    alert(errorThrown);
                }
                //$('#errorMessages')
                //    .append($('<li>')
                //        .attr({ class: 'list-group-item list-group-item-danger' })
                //        .text('Error calling web service.  Please try again later.'));
            }
        });
    });


    
});

//returns the id of product to our item textbox
function fnSelectItem(id) {
    $("#txtItem").val(id);
    $("#txtChange").val("");
    $("#txtMessage").val("");
}

//calculates the amount entered and returns to our total $ box
function fnAddMoney(amount) {
    var amt = amount + parseFloat($("#txtTotal").val());
    $("#txtTotal").val(Number.parseFloat(amt).toFixed(2));
    $("#txtChange").val("");
    $("#txtMessage").val("");
    
}


function fnChangeReturn(amount) {
    var quarters = 0;
    var dimes = 0;
    var nickels = 0;
    var rtnString = "";

    var change = parseFloat(amount)*100;


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



function fnConvertOutput(data, status) {
    if (status === "success") {
        var outputString = "";
        $("#txtTotal").val(0);
        $("#txtItem").val("");
       
        outputString += data.quarters > 0 ? data.quarters + " Quarter(s) " : "";
        outputString += data.dimes > 0 ? data.dimes + " Dime(s) " : "";
        outputString += data.nickels > 0 ? data.nickels + " Nickel(s) " : "";
        $("#txtChange").val(outputString);
        $("#txtMessage").val("Thank You!!!");
    } else {
        $("#txtMessage").val(data.message);
        $("#txtChange").val("");

    }


}
function clearItems() {
    $('#productBody').empty();

}


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
            displayItems(data, status);
        },
        error: function (jqXHR, textStatus, errorThrown) {
         
                alert(errorThrown);
            
           
        }
    });

}


function displayItems(data) {
    var contentRows = $('#productBody');
    var count = 0;
    var row = "";
    var dataLength = data.length;
    row += '<div class="row">';
    $.each(data, function (index, item) {
        var id = item.id;
        var name = item.name;
        var price = item.price;
        var quantity = item.quantity;
      
        count++;
       
        row += '<div class="col-sm-4 text-center" >';
        row += '        <div id="product" onclick="fnSelectItem(' + id + ')"  tabIndex="' + count + '">';
        row += '            <p style="text-align:left ; padding-left:5px;">' + id + '</p>';
        row += '            <h3>' + name + '</h3>';
        row += '            <p>Price: $' + price + '</p>';
        row += '            <p>Quantity: ' + quantity + '</p>';
        row += '        </div>';
        row += '</div>';
        if (count % 3 === 0) {
            row += '</div>';
            contentRows.append(row);
            if (count != dataLength)
            {
                row = '<div class="row">';
            }
            
        }
       



    });


}

