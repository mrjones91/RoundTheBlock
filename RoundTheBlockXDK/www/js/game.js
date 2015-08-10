enchant();

var gameWidth = 588;
var gameHeight = 940;
var game = new Core(gameWidth, gameHeight);
var background, ball, paddle, blocks;

game.preload('./asset/textures/backgrounds/bgDark.jpg', './asset/arkPaddle.png', './asset/ball.png', './asset/blocks.png');

var frame = 0, bgf = 0;
var level = 0;

game.onload = function(){
		
	gameObjectLoad();
	ball = new Ball(25);
	paddle = new Paddle(128, 30);
	blocks  = new Array(18);
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
	
	game.rootScene.addChild(background);
	game.rootScene.addChild(paddle);
	game.rootScene.addChild(ball);
	for (var i = 0; i < blocks.length; i++)
	{
		game.rootScene.addChild(blocks[i]);
	}
	
	/*var block = new Sprite(65, 34);
	block.image = game.assets['./asset/blocks.png'];
	block.frame = 5;
	game.rootScene.addChild(block);*/

	

	// var xmlhttp;
	// if (window.XMLHttpRequest)
 //  	{// code for IE7+, Firefox, Chrome, Opera, Safari
 //  		xmlhttp=new XMLHttpRequest();
 //  	}
	// else
 // 	{// code for IE6, IE5
	// 	xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
	// }
	// xmlhttp.onreadystatechange=function(){
	// 	if (xmlhttp.readyState==4 && xmlhttp.status==200)
 //    	{
 //    		console.log(xmlhttp.responseText);

 //    		var testBlocks = new Array();
    		
 //    		for (var i = 0; i < xmlhttp.responseText.length; i++)
 //    		{

 //    		}
 //    	}
	// }
	// xmlhttp.open('GET', './levels/test00',true);
	// xmlhttp.send();

	//game.rootScene.addChild(ball);
	///---Ball---///

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
};

game.start();