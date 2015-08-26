//Call functionality of game objects

var gameObjectLoad = function() {

	Block.prototype.die = function() {
		if (this.within(ball))
			{
				gameScene.removeChild(this);
                //ball collision 
                //BUG - (still goes through multiple blocks with enough speed + angle)
                if (this.height <= ball.height)
                {
                    ball.dx = 32 * ((ball.x-(this.x + this.width/2))/this.width);
                    ball.dy = - ball.dy;
                } else if (this.height >= ball.height)
                {
                    ball.dx = 32 * ((ball.x-(this.x + this.width/2))/this.width);
                    ball.dy = - ball.dy;
                }
			}
	};

	Ball.prototype.move = function() {
        //boundaries
        ///change directions
        //BUG - (speed + angle can through ball out of bounds)
		if (this.x > game.width - this.width || this.x < 0)
            this.dx = - this.dx;
        if (this.y < 0)
            this.dy = - this.dy;
        
        //reset locations
        if (this.y > gameHeight || this.x < 0 - this.width || this.x > game.width)
        {
            this.x = this.y = 0;
            background.next();
        }
        if (this.intersect(paddle) && (this.height <= paddle.height))
        {
            this.dx = 32 * ((this.x-(paddle.x +paddle.width/2))/paddle.width);
            this.dy = - this.dy;
        }
            this.x += this.dx;
            this.y += this.dy;
	};
}

var loadLevel = function(level){
///Testing AJAX call for Level data///
    var xmlhttp;
    if (window.XMLHttpRequest)
    {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp=new XMLHttpRequest();
    }
    else
    {// code for IE6, IE5
        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange=function(){
        if (xmlhttp.readyState==4 && xmlhttp.status==200)
        {
            console.log(xmlhttp.responseText);
            var data = JSON.parse(xmlhttp.responseText);
            var rows = [];
            rows.push(data.rows.a);
            rows.push(data.rows.b);
            rows.push(data.rows.c);
            rows.push(data.rows.d);
            rows.push(data.rows.e);
            rows.push(data.rows.f);
            rows.push(data.rows.g);
            
            clearBlocks();

            for (var i = 0; i < rows.length; i++)
            {
                for (var j = 0; j < rows[i].length; j++)
                {
                    blocks.push(new Block(rows[i][j], i, j));
                }
            }
            for(var i = 0; i < blocks.length; i++)
            {
                gameScene.addChild(blocks[i]);
            }
        }
        else if (xmlhttp.responseText == '') {

        }
    }
    var levelName = './levels/' + level + '.json';
    console.log(levelName);
    xmlhttp.open('GET', levelName,true);
    xmlhttp.send();
///---Testing AJAX call for Level data---///
}

var clearBlocks = function() {
            for (var i = 0; i < blocks.length; i++)
            {
                blocks[i].destroy();
            }
            blocks = [];
        }
function makeSelect(text, y) {    var label = new Label(text);    label.font  = "16px monospace";    label.color = "rgb(255,200,0)";    label.y     = y;    label.width = 320;    return label; }