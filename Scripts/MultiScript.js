var myMazeBoard;
var otherMazeBoard;
var multiHub = $.connection.multiHub;
var WinUri = 'api/Users/PostWin';
var LoseUri = 'api/Users/PostLose';
//var selectList;
multiHub.client.gotMessage = function (text) {
    //$("#lstMessages").append("<li><strong>" + senderPhoneNum + "</strong>:" + text + "</li>");
    if (text[0] == '[') {

        var res = text.split("[");
        var res2 = res[1].split("]");
        var res3 = res2[0].split(",");
        //myDiv = document.getElementById("list");

        selectList = document.getElementById("list");
        //selectList.id = "mySelect";
        //myDiv.appendChild(selectList);
        for (var j = 0; j < res3.length; j++) {
            if (res3[j] != "") {
                var option = document.createElement("option");
                option.value = res3[j];
                option.text = res3[j];
                selectList.appendChild(option);
            }
        }
    }
    else if (text[0] == "{") {
        if (text.includes("Direction")) {
            var d;
            if (text.includes("right")) {
                d = 1;
            }
            else if (text.includes("left")) {
                d = 0;
            }
            else if (text.includes("up")) {
                d = 2;
            }
            else if (text.includes("down")) {
                d = 3;
            }
            var result = otherMazeBoard.move(d, otherMazeBoard, 1);
            if (result == -1) {
                var username = sessionStorage.getItem("username");
                /*$.post(LoseUri, username).done(function (item) {
                    //self.Users.push(item);
                    alert("lose22");
                });*/
                //$.ajax({
                //    url: LoseUri,
                //    type: 'POST',
                //    dataType: "string",
                //    data: username
                    
                //});


                var user1 = {
                    UserName: username,
                };
                $.post(LoseUri, user1).done(function () {
                    //self.Users.push(item);
                    alert("hi");
                });

            }
            else {

                //var myImage = document.getElementById("myImage");
                //var jobj = JObject.Parse(text);
                //myMazeBoard = $("#myMazeCanvas").PlugdrawMaze(jobj, myImage);
                //var otherImage = document.getElementById("otherImage");
                //otherMazeBoard = $("#otherMazeCanvas").PlugdrawMaze(jobj, otherImage);
                //alert(text);

            }
        }
    }
    else {
        if (!text.includes("got your move")) {
            alert(text);
        }
    }
};
function checkKey(e) {

    e = e || window.event;
    var username = sessionStorage.getItem("username");
    var commandLine;
    if (e.keyCode == '38') {
        // up arrow- 2
        var result = myMazeBoard.move(2, myMazeBoard, 0);
        if (result == 1) {
            var user1 = {
                UserName: username,
            };
            $.post(WinUri, user1).done(function () {
                //self.Users.push(item);
                alert("win22");
            });
        }

        commandLine = "play up";
        multiHub.server.getMessageFromClient(username, commandLine);
    }
    else if (e.keyCode == '40') {
        // down arrow - 3
        var result = myMazeBoard.move(3, myMazeBoard, 0);

        if (result == 1) {
            var user1 = {
                UserName: username,
            };
            $.post(WinUri, user1).done(function () {
                //self.Users.push(item);
                alert("win22");
            });
        }
        commandLine = "play down";
        multiHub.server.getMessageFromClient(username, commandLine);
    }
    else if (e.keyCode == '37') {
        // left arrow - 0
        var result = myMazeBoard.move(0, myMazeBoard, 0);

        if (result == 1) {
            var user1 = {
                UserName: username,
            };
            $.post(WinUri, user1).done(function () {
                //self.Users.push(item);
                alert("win22");
            });
        }
        commandLine = "play left";
        multiHub.server.getMessageFromClient(username, commandLine);
    }
    else if (e.keyCode == '39') {
        // right arrow - 1
        var result = myMazeBoard.move(1, myMazeBoard, 0);

        if (result == 1) {
            var user1 = {
                UserName: username,
            };
            $.post(WinUri, user1).done(function () {
                //self.Users.push(item);
                alert("win22");
            });
        }
        commandLine = "play right";
        multiHub.server.getMessageFromClient(username, commandLine);
    }

}

multiHub.client.gotMazeMessage = function (text) {
    document.onkeydown = checkKey;
    var myImage = document.getElementById("myImage");
    //var jobj = JObject.Parse(text);
    myMazeBoard = $("#myMazeCanvas").PlugdrawMaze(text, myImage);
    //var otherImage = document.getElementById("otherImage");
    otherMazeBoard = $("#otherMazeCanvas").PlugdrawMaze(text, otherImage);
}
$.connection.hub.start().done(function () {
    //$('#btnConnect').click(function () {
    var username = sessionStorage.getItem("username");
    multiHub.server.connect(username);
    // })
    $("#btnStart").click(function () {

        //var username = $("#userPhoneNum").val();
        var username = sessionStorage.getItem("username");
        var commandLine = "start " + $("#mazeName").val() + " " + $("#rows").val() + " " + $("#cols").val();
        multiHub.server.getMessageFromClient(username, commandLine);
    });
    $("#list").click(function () {

        //var username = $("#userPhoneNum").val();
        var username = sessionStorage.getItem("username");
        var commandLine = "list";
        multiHub.server.getMessageFromClient(username, commandLine);
    });
    $("#btnJoin").click(function () {

        //var username = $("#userPhoneNum").val();
        var username = sessionStorage.getItem("username");
        var commandLine = "join " + $("#list").val();
        multiHub.server.getMessageFromClient(username, commandLine);
    });
});