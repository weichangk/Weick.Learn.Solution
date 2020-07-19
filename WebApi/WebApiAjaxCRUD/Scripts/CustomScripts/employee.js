$(document).ready(function () {
    GetAllEmployees();
});

function GetAllEmployees() {
    $.ajax({
        url: 'api/EmployeesAPI',
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.EmployeeID + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Age + '</td>';
                html += '<td>' + item.State + '</td>';
                html += '<td>' + item.Country + '</td>';
                html += '<td><a href="#" onclick="return GetEmployeeByID(' + item.EmployeeID + ')">Edit</a> | <a href="#" onclick="DeleteEmployee(' + item.EmployeeID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function GetEmployeeByID(employeeId) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');

    $.ajax({
        url: 'api/EmployeesAPI/' + employeeId,
        type: 'GET',
        dataType: 'json',
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            $('#EmployeeID').val(result.EmployeeID);
            $('#Name').val(result.Name);
            $('#Age').val(result.Age);
            $('#State').val(result.State);
            $('#Country').val(result.Country);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {            
            alert(errormessage.responseText);
        }
    });
}

function AddEmployee() {
    var res = Validate();
    if (res == false) {
        return false;
    }

    var employeeObject = {
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        State: $('#State').val(),
        Country: $('#Country').val()
    };
   
    $.ajax({
        url: 'api/EmployeesAPI',
        type: 'POST',
        data: JSON.stringify(employeeObject),
        contentType: "application/json;charset=utf-8",
        success: function (result) {           
            GetAllEmployees();
            $('#myModal').modal('hide');            
            $('.modal-backdrop').remove();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function UpdateEmployee() {
    var res = Validate();
    if (res == false) {
        return false;
    }

    var employeeObject = {
        EmployeeID: $('#EmployeeID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),              
        State: $('#State').val(),
        Country: $('#Country').val()
    };

    $.ajax({
        url: 'api/EmployeesAPI/',
        type: 'PUT',
        data: JSON.stringify(employeeObject),
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            GetAllEmployees();
            $('#myModal').modal('hide');
            $('#EmployeeID').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#State').val("");
            $('#Country').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function DeleteEmployee(employeeId) {
    bootbox.confirm("Are you sure you want to delete?", function(result){  
        if (result) {
            $.ajax({
                url: 'api/EmployeesAPI/' + employeeId,
                type: 'DELETE',
                data: 'json',
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    GetAllEmployees();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    })
}

function Validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Age').val().trim() == "") {
        $('#Age').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Age').css('border-color', 'lightgrey');
    }
    if ($('#State').val().trim() == "") {
        $('#State').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#State').css('border-color', 'lightgrey');
    }
    if ($('#Country').val().trim() == "") {
        $('#Country').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Country').css('border-color', 'lightgrey');
    }
    return isValid;
}

function clearTextBox() {
    $('#EmployeeID').val("");
    $('#Name').val("");
    $('#Age').val("");
    $('#State').val("");
    $('#Country').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}

