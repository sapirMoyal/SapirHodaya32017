$(document).ready(function () {
    if (sessionStorage.getItem("username") != null) {
        $('#registerId').hide();
        $('#loginId').hide();
        $('#logoutId').show();
        $('#userId').show();
        var value = sessionStorage.getItem("username");
        document.getElementById('userId').innerText = "Hello " + value;
        
    }
    else {
        $('#registerId').show();
        $('#loginId').show();
        $('#logoutId').hide();
        
        $('#userId').hide();
    }
});