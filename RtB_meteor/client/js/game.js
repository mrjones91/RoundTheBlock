if (Meteor.isClient){
	enchant();

// var gameWidth = 588;
// var gameHeight = 940;
// var game = new Core(gameWidth, gameHeight);
var ball = new Ball(25);
var paddle = new Paddle(128, 30);
var blocks  = new Array(8);
	for (var i = 0; i < blocks.length; i++)
	{
		blocks[i] = new Block(i);
		if (i >= 1)
		{
			blocks[i].x += blocks[i].width + blocks[i - 1].x;
		}
		//game.rootScene.addChild(blocks[i]);
	};
//game.preload('./asset/textures/backgrounds/00a.jpg', './asset/textures/backgrounds/01a.jpg', './asset/textures/backgrounds/02.jpg', './asset/textures/backgrounds/03.jpg', './asset/textures/backgrounds/04.jpg', './asset/textures/backgrounds/05.jpg', './asset/textures/backgrounds/06.jpg', './asset/textures/backgrounds/07.jpg', './asset/textures/backgrounds/08.jpg', './asset/textures/backgrounds/09.jpg');
game.preload('./asset/textures/backgrounds/bgDark.jpg', './asset/arkPaddle.png', './asset/ball.png', './asset/blocks.png');
var frame = 0, bgf = 0;
var level = 0;
//alert(game.fps);
game.onload = function(){

	///Background///
	var background = new Sprite(603, 940);
	background.image = game.assets['./asset/textures/backgrounds/bgDark.jpg'];
	background.frame = bgf;
	background.addEventListener(Event.ENTER_FRAME, function(){
	});
	game.rootScene.addChild(background);
	///---Background---///

	//var paddle = new Paddle(128, 30);
	//  Sprite(128, 30);
	// paddle.y = 800;
	// paddle.image = game.assets['./asset/arkPaddle.png'];
	// //paddle.frame = [8, 9, 10, 11];
	// paddle.frame = [0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3];
	

	///Ball///
	
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

	game.rootScene.addChild(ball);
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

}