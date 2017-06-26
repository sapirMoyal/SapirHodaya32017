
(function ($) {

    $.fn.PlugdrawMaze = function (data, img) {
        var rowPlayer;
        var colPlayer;
        var startRow = data.Start.Row;
        var startCol = data.Start.Col;
        var EndRow = data.End.Row;
        var EndCol = data.End.Col;

        var myCanvas = $(this)[0]
        context = myCanvas.getContext("2d");
        context.strokeStyle = "#000000";
        context.strokeRect(0, 0, myCanvas.width, myCanvas.height);
        var rows = data.Rows;
        var numOfrows = rows;
        var cols = data.Cols;
        var maze = data.Maze;
        var cellWidth = myCanvas.width / cols;
        var cellHeight = myCanvas.height / rows;
        var imgWidth = myCanvas.width / (cols) - 2;
        var imgHeight = myCanvas.height / (rows) - 2;
        var c = 0;
        var numOfcols = rows;
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                if (maze[c] == 1) {
                    context.fillRect(cellWidth * j, cellHeight * i,
                        cellWidth, cellHeight);
                }

                if (i == startRow && j == startCol) {
                    context.drawImage(img, cellWidth * j + 1, cellHeight * i + 1, imgWidth, imgHeight);
                    colPlayer = j;
                    rowPlayer = i;
                }
                if (i == EndRow && j == EndCol) {
                    var imgY = document.getElementById("imageYamina");
                    context.drawImage(imgY, cellWidth * j, cellHeight * i, cellWidth, cellHeight);
                   
                }
                c++;
            }

        }
        var move = function (d, obj, type) {
            
            context = obj.myCanvas.getContext("2d");
            if (d == 0) {
               
                if (obj.colPlayer > 0 && maze[obj.rowPlayer * (numOfcols) + obj.colPlayer - 1] != 1) {
                    context.fillStyle = "white";
                    context.fillRect(cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                    obj.colPlayer = obj.colPlayer - 1;
                    context.drawImage(img, cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                }

            }
            else if (d == 1) {
                
                if (obj.colPlayer + 1 < numOfcols && maze[obj.rowPlayer * (numOfcols) + obj.colPlayer + 1] != 1) {
                    context.fillStyle = "white";
                    context.fillRect(cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                    obj.colPlayer = obj.colPlayer + 1;
                    context.drawImage(img, cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                }
            }
            else if (d == 2) {
                
                if (obj.rowPlayer > 0 && maze[(obj.rowPlayer - 1) * (numOfcols) + obj.colPlayer] != 1) {
                    context.fillStyle = "white";
                    context.fillRect(cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                    obj.rowPlayer = obj.rowPlayer - 1;
                    context.drawImage(img, cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                }

            }
            else if (d == 3) {
               
                if (obj.rowPlayer + 1 < numOfrows && maze[(obj.rowPlayer + 1) * (numOfcols) + obj.colPlayer] != 1) {
                    context.fillStyle = "white";
                    context.fillRect(cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                    obj.rowPlayer = obj.rowPlayer + 1;
                    context.drawImage(img, cellWidth * obj.colPlayer + 1, cellHeight * obj.rowPlayer + 1, imgWidth, imgHeight);
                }
            }
            if (obj.rowPlayer == EndRow && obj.colPlayer == EndCol) {
                var imgY = document.getElementById("imageYamina");
                context.drawImage(imgY, cellWidth * obj.colPlayer, cellHeight * obj.rowPlayer, cellWidth, cellHeight);
                if (type == 0) {
                    alert("win!");
                    return 1;
                }
                if (type == 1) {
                    alert("lose!");
                    return -1;
                }
                return 0;
            }
        }
        var obj = {
            maze: maze,
            rowPlayer: rowPlayer,
            colPlayer: colPlayer,
            numOfcols: numOfcols,
            numOfrows: numOfrows,
            cellHeight: cellHeight,
            cellWidth: cellWidth,
            context: context,
            startRow: startRow,
            startCol: startCol,
            EndRow: EndRow,
            EndCol: EndCol,
            imgWidth: imgWidth,
            imgHeight: imgHeight,
            move: move,
            img: img,
            myCanvas: myCanvas
        }
        return obj;

    }
})(jQuery);