$(document).ready(function () {
    loadDvds();
    $('#createdvdbtn').click(function (event) {
        showCreateDisplay();
    });
    $("#create-form-button").click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#create-form').find('input'));
        if (haveValidationErrors) {
            return false;
        }
        $.ajax({
            type: 'POST',
            url: 'http://localhost:58061/dvd',
            data: JSON.stringify({
                title: $('#create-title').val(),
                realeaseYear: $('#create-release-year').val(),
                director: $('#create-director').val(),
                rating: $('#create-rating').val(),
                notes: $('#create-notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                $('#create-title').val('');
                $('#create-release-year').val('');
                $('#create-director').val('');
                $('#create-rating').val('');
                $('#create-notes').val('');
                $('#searchResults').hide();
                $('#searchResults').empty();
                $('#content').show();
                loadDvds();
                showHomeDisplay();
            },
            error: function () {
                $("#errorMessages")
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
        });
    });
    $('#create-form-cancel-button').click(function (event) {
        showHomeDisplay();
    });
    $("#searchbtn").click(function (event) {
        cleardvdTable();
        $('#searchResults').empty();
        var haveValidationErrors = checkAndDisplayValidationErrors($("#search").find('input'));
        if (haveValidationErrors) {
            return false;
            loadDvds();
            showHomeDisplay();
        }
        $.ajax({
            type: 'GET',
            url: 'http://localhost:58061/dvds/' + $('#dropdownbox').val() + '/' + $('#searchtxtbox').val(),
            success: function (dvdArray) {
                $.each(dvdArray, function (index, dvd) {
                    var title = dvd.title;
                    var releaseDate = dvd.realeaseYear;
                    var director = dvd.director;
                    var rating = dvd.rating;
                    var dvdId = dvd.dvdId;
                    var row = '<tr>';
                    row += '<td><a onclick="gotoTitle(' + dvdId + ')">' + title + '</a></td>';
                    row += '<td>' + releaseDate + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a> | <a id="deleteConfirm" onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';
                    row += '</tr>';
                    cleardvdTable();
                    $('#searchResults').append(row);
                    $('#dropdownbox').val('');
                    $('#searchtxtbox').val('');
                    $('#content').hide();
                    $('#searchResults').show();
                    $('#backbtn').show();
                });
            },
            error: function () {
                $("#errorMessages")
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
        });
    });
    $('#backbtn').click(function (event) {
        $('#dropdownbox').val('');
        $('#searchtxtbox').val('');
        $('#searchResults').hide();
        $('#backbtn').hide();
        $('#content').show();
        loadDvds();
        showHomeDisplay();
    });
    $('#edit-button').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($("#edit-form").find('input'));
        if (haveValidationErrors) {
            return false;
        }
        $.ajax({
            type: 'PUT',
            url: 'http://localhost:58061/dvd/' + $('#edit-dvd-id').val(),
            data: JSON.stringify({
                dvdId: $('#edit-dvd-id').val(),
                title: $('#edit-title').val(),
                realeaseYear: $('#edit-release-year').val(),
                director: $('#edit-director').val(),
                rating: $('#edit-rating').val(),
                notes: $('#edit-notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $("#errorMessages").empty();
                hideEditForm();
                loadDvds();
                showHomeDisplay();
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
        });
    });
    $('#edit-cancel-button').click(function (event) {
        showHomeDisplay();
    });
});
// end of on load function
function loadDvds() {
    cleardvdTable();
    var content = $("#content");
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58061/dvds/',
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseDate = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var dvdId = dvd.dvdId;
                var row = '<tr>';
                row += '<td><a onclick="gotoTitle(' + dvdId + ')">' + title + '</a></td>';
                row += '<td>' + releaseDate + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a> | <a onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';
                row += '</tr>';
                content.append(row);
            });
        },
        error: function () {
            $("#errorMessages")
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text("Error calling web service. Please try again later."));
        }
    });
}
function showCreateDisplay() {
    $('#errorMessages').empty();
    $('#header').hide();
    $('#displayHome').hide();
    $('#editheader').hide();
    $('#editDisplay').hide();
    $('#displayheader').show();
    $('#createDisplay').show();
}
function showHomeDisplay() {
    $('#errorMessages').empty();
    $('#header').show();
    $('#displayHome').show();
    $('#editheader').hide();
    $('#editDisplay').hide();
    $('#displayheader').hide();
    $('#createDisplay').hide();
    $('#detailheader').hide();
    $('#detailTable').hide();
    $('#backbtn').hide();
}
function showEditDisplay() {
    $('#errorMessages').empty();
    $('#header').hide();
    $('#displayHome').hide();
    $('#editheader').show();
    $('#editDisplay').show();
    $('#displayheader').hide();
    $('#createDisplay').hide();
}
function gotoTitle(dvdId) {
    cleardvdTable();
    $('#errorMessages').empty();
    var detailcontent = $('#detailcontent');
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58061/dvd/' + dvdId,
        success: function (data, status) {
            $('#headerdetail').val(data.title);
            var title = data.title;
            $('#headerdetail').text(title);
            var dvdId = data.dvdId;
            var releaseDate = data.realeaseYear;
            var director = data.director;
            var rating = data.rating;
            var notes = data.notes;
            var table = '<tr>';
            table += '<td>Release Year:</td>';
            table += '<td>' + releaseDate + '</td>';
            table += '</tr><tr>';
            table += '<td>Director:</td>';
            table += '<td>' + director + '</td>';
            table += '</tr><tr>';
            table += '<td>Rating:</td>';
            table += '<td>' + rating + '</td>';
            table += '</tr><tr>';
            table += '<td>Notes:</td>';
            table += '<td>' + notes + '</td>';
            table += '</tr>';
            detailcontent.append(table);
        },
        error: function () {
            $("#errorMessages")
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text("Error calling web service. Please try again later."));
        }
    });
    $('#header').hide();
    $('#displayHome').hide();
    $('#detailheader').show();
    $('#detailTable').show();
}
function showEditForm(dvdId) {
    $('#errorMessages').empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58061/dvd/' + dvdId,
        success: function (data, status) {
            var headeredit = "Edit Dvd: " + data.title;
            $('#headeredit').text(headeredit);
            $('#edit-title').val(data.title);
            $('#edit-release-year').val(data.realeaseYear);
            $('#edit-director').val(data.director);
            $('#edit-rating').val(data.rating);
            $('#edit-notes').val(data.notes);
            $('#edit-dvd-id').val(data.dvdId);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-danger' })
                .text('Error calling web service. Please try again later.');
        }
    });
    showEditDisplay();
}
function hideEditForm() {
    $('#errorMessages').empty();
    $('#edit-title').val('');
    $('#edit-release-year').val('');
    $('#edit-director').val('');
    $('#edit-rating').val('');
    $('#edit-notes').val('');
    showHomeDisplay();
}
function deleteDvd(dvdId) {
    $.confirm({
        title: 'Confirmation',
        content: 'Are you sure you want to delete this Dvd from your collection?',
        buttons: {
            confirm: function () {
                $.alert('Title deleted!');
                $.ajax({
                    type: 'DELETE',
                    url: 'http://localhost:58061/dvd/' + dvdId,
                    success: function () {
                        loadDvds();
                        showHomeDisplay();
                    },
                    error: function () {
                        loadDvds();
                        showHomeDisplay();
                    }
                });
            },
            cancel: function () {
                $.alert('Canceled!');
            }
        }
    });
}
function cleardvdTable() {
    $("#content").empty();
}
function checkAndDisplayValidationErrors(input) {
    $("#errorMessages").empty();
    var errorMessages = [];
    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            var errorMessage = this.value;
            errorMessages.push('invalid input.');
            $('#backbtn').show();
        }
    });
    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        return true;
    } else {
        return false;
    }
}
