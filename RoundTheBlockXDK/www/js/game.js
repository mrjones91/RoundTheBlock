enchant();

///Global Variables / Game Objects ///
var gameWidth = 588;
var gameHeight = 940;
var game = new Core(gameWidth, gameHeight);
var background, ball, paddle, blocks;

game.preload('./asset/textures/backgrounds/bgDark.jpg', './asset/arkPaddle.png', './asset/ball.png', './asset/blocks.png');

//can likely remove due to refactor of background
//var frame = 0, bgf = 0;
var level = 0;

game.onload = function(){

///Initiliaze game objects/functions///
	gameObjectLoad();
	ball = new Ball(25);
	paddle = new Paddle(128, 30);
	blocks  = new Array(0);
	background = new Background();
	for (var i = 0; i < blocks.length; i++)
	{
		blocks[i] = new Block(i);
		if (i >= 1)
		{
			blocks[i].x += blocks[i].width + blocks[i - 1].x;
			if (blocks[i].x >= game.width){
				blocks[i].x = 0;
				blocks[i].y += blocks[i].height;
			}
		}

	};
///---Initiliaze game objects/functions---///

///Add Game Objects to scene///
	game.rootScene.addChild(background);
	game.rootScene.addChild(paddle);
	game.rootScene.addChild(ball);
	for (var i = 0; i < blocks.length; i++)
	{
		game.rootScene.addChild(blocks[i]);
	}
///---Add Game Objects to scene---///	
	
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

    		var testBlocks = new Array();
    		var data = JSON.parse(xmlhttp.responseText);
    		var rows = [];
    		rows.push(data.rows.a);
    		rows.push(data.rows.b);
    		rows.push(data.rows.c);
    		rows.push(data.rows.d);
    		rows.push(data.rows.e);
    		rows.push(data.rows.f);
    		rows.push(data.rows.g);
    		var rowa = data.rows.a;
    		console.log(rows.length)
    		for (var i = 0; i < rows.length; i++)
    		{
    			for (var j = 0; j < rows[i].length; j++)
    			{
    				console.log(rows[i][j]);
    				console.log(j);
	    			switch(rows[i][i])
	    			{
	    				case '0':
	    				blocks.push(new Block(rows[i][i], 'a', i));
	    				game.rootScene.addChild(blocks[i]);
	    				break;
	    				case '1':
	    				blocks.push(new Block(rowb[i], 'b', i));
	    				game.rootScene.addChild(blocks[i]);
	    				break;
	    			}
    				
    			}
    			console.log(rows);
    			console.log(rows[0]);
    			console.log(rows[1]);
    		}
    	}
	}
	xmlhttp.open('GET', './levels/test00.json',true);
	xmlhttp.send();
///---Testing AJAX call for Level data---///

///Game Inputs///
	game.rootScene.addEventListener(Event.LEFT_BUTTON_DOWN, function(){
		paddle.x -= 5;
	});
	game.rootScene.addEventListener(Event.RIGHT_BUTTON_DOWN, function(){
		paddle.x += 5;
	});

	game.rootScene.addEventListener(Event.TOUCH_START, function(evt){
		paddle.x = evt.localX - 75;
	});
	game.rootScene.addEventListener(Event.TOUCH_MOVE, function(evt){
		paddle.x = evt.localX - 75;
	});
///---Game Inputs---///
};//End game.onload

game.start();