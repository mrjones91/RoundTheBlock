enchant();

var gameWidth = 588;
var gameHeight = 940;
var game = new Core(gameWidth, gameHeight);
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
		/*frame++;
		if ((frame % 10) == 0)
		{
			bgf++;
			background.frame = bgf;
		}*/
	});
	game.rootScene.addChild(background);
	///---Background---///

	var paddle = new Sprite(128, 30);
	paddle.y = 800;
	paddle.image = game.assets['./asset/arkPaddle.png'];
	//paddle.frame = [8, 9, 10, 11];
	paddle.frame = [0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3];
	game.rootScene.addChild(paddle);

	///Ball///
	var ball = new Sprite(25, 25);
	ball.dx = 1.5;
	ball.dy = 16;
	ball.image = game.assets['./asset/ball.png'];
	
	ball.addEventListener(Event.ENTER_FRAME, function () {
		if (ball.x > game.width - ball.width || ball.x < 0)
			ball.dx = - ball.dx;
		if (ball.y < 0)
			ball.dy = - ball.dy;
		if (ball.y > game.height || ball.x < 0 - ball.width || ball.x > game.width)
		{
			ball.x = ball.y = 0;
			bgf++;
			background.frame = bgf;
		}
		if (ball.intersect(paddle) && (ball.height < paddle.height))
		{
			ball.dx = 32 * ((ball.x-(paddle.x +paddle.width/2))/paddle.width);
			ball.dy = - ball.dy;
		}
		if (ball.intersect(blocks))
		{

			ball.dx = 32 * ((ball.x-(blocks.x + blocks.width/2))/blocks.width);
			ball.dy = - ball.dy;
		}
		//console.log(ball.dx);
		ball.x += ball.dx;
		ball.y += ball.dy;
	});

	/*var block = new Sprite(65, 34);
	block.image = game.assets['./asset/blocks.png'];
	block.frame = 5;
	game.rootScene.addChild(block);*/

	Block = Class.create(Sprite, {
		initialize: function(frm){
			enchant.Sprite.call(this, 65, 34);
			this.image = game.assets['./asset/blocks.png'];
			this.frame = frm;
			this.y = 225;
			this.addEventListener(Event.ENTER_FRAME, this.die);
		},
		die: function() {
			if (this.intersect(ball))
			{
				game.rootScene.removeChild(this);
			}
		}
	});

	var blocks = new Array(5);
	
	for (var i = 0; i < blocks.length; i++)
	{
		blocks[i] = new Block(i);
		if (i >= 1)
		{
			blocks[i].x += blocks[i].width + blocks[i - 1].x;
		}
		game.rootScene.addChild(blocks[i]);
	}

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
    		
    		for (var i = 0; i < responseText.length; i++)
    		{

    		}
    	}
	}
	xmlhttp.open('GET', './levels/test00',true);
	xmlhttp.send();

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