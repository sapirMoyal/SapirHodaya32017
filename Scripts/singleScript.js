var myMazeBoard;
function initFunc() {
    var value = localStorage.getItem('rows');
    if (typeof value !== 'undefined') {
        $('input[name=rows]').val(value);
    }
    var value = localStorage.getItem('cols');
    if (typeof value !== 'undefined') {
        $('input[name=cols]').val(value);
    }
    var value = localStorage.getItem('alg');
    if (typeof value !== 'undefined') {
        $('#selectAlg').val(value);
        
    }
}
onload = initFunc;

function checkKey(e) {

    e = e || window.event;

    if (e.keyCode == '38') {
        // up arrow- 2
        myMazeBoard.move(2, myMazeBoard, 0);

    }
    else if (e.keyCode == '40') {
        // down arrow - 3
        myMazeBoard.move(3, myMazeBoard, 0);
    }
    else if (e.keyCode == '37') {
        // left arrow - 0
        myMazeBoard.move(0, myMazeBoard, 0);
    }
    else if (e.keyCode == '39') {
        // right arrow - 1
        myMazeBoard.move(1, myMazeBoard, 0);
    }
}

function drawMaze(data) {
    document.onkeydown = checkKey;
    $('.loader').hide();
    var img = document.getElementById("image");
    myMazeBoard = $("#mazeCanvas").PlugdrawMaze(data, img);
}


function generate() {

    var uri = '/api/Single';
    var idN = $('#mazeName').val();
    var idR = $('#rows').val();
    var idC = $('#cols').val();

    $.getJSON(uri + "/" + idN + "/" + idR + "/" + idC).done(function (data) {
       
        //maze = data.mazeString;
        drawMaze(data);
    })
}
function SolveMaze() {
    var uri = '/api/Single';
    var idN = $('#mazeName').val();
    alert(idN);
    context.fillStyle = "white";
    context.fillRect(myMazeBoard.cellWidth * myMazeBoard.colPlayer, myMazeBoard.cellHeight * myMazeBoard.rowPlayer, myMazeBoard.cellWidth, myMazeBoard.cellHeight);
    myMazeBoard.rowPlayer = myMazeBoard.startRow;
    myMazeBoard.colPlayer = myMazeBoard.startCol;
    var img = document.getElementById("image");
    context.drawImage(img, myMazeBoard.cellWidth * myMazeBoard.startCol, myMazeBoard.cellHeight * myMazeBoard.startRow, myMazeBoard.cellWidth, myMazeBoard.cellHeight);
    $.getJSON(uri + "/" + idN).done(function (solve) {
        var res = solve.split(",");
        var i = -1;
        function moveSolve(i) {
            if (res[i] == "Right") {
                myMazeBoard.move(1, myMazeBoard, 0);
            }
            if (res[i] == "Up") {
                myMazeBoard.move(2, myMazeBoard, 0);
            }
            if (res[i] == "Left") {
                myMazeBoard.move(0, myMazeBoard, 0);
            }
            if (res[i] == "Down") {
                myMazeBoard.move(3, myMazeBoard, 0);
            }
        }
        if (i < res.length) {
            setInterval(function () { moveSolve(++i) }, 1000);
        }
    })
}