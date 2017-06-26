var UserUri = '/api/users/';

function sub() {
	if (document.getElementById("inputpassword").value != document.getElementById("inputpassword2").value) {
		alert("The passwords is not equal. please try enter the password again");
	}
	else {
		var passwordHash = document.getElementById("inputpassword").value;
		var user1 = {
			UserName: document.getElementById("inputUsername").value,
			UserPassword: passwordHash,
			UserEmail: document.getElementById("inputEmail").value
		};
		$.post(UserUri, user1).done(function () {
			//self.Users.push(item);
			alert("hi");
		});
	}
};