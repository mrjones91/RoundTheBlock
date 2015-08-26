var loadGameScene = function() {
	loadLevel(level);
//Tentatively 1 game scene with multiple background
///Add Game Scene objects///
	///Initiliaze game objects/functions///
		gameObjectLoad();
		ball = new Ball(25);
		paddle = new Paddle(128, 30);
		ball.x = paddle.x + (.5 * paddle.width);
	    ball.y = paddle.y - ball.height;
		background = new Background();
		blocks = [];
	///---Initiliaze game objects/functions---///
	///Add Game Objects to scene///
		gameScene.addChild(background);
		gameScene.addChild(paddle);
		gameScene.addChild(ball);
		sign = new Label();
		sign.text = 'Hello World';
		sign.x = 0;
		sign.y = 0;
		sign.font = "28px sans-serif";
		sign.color = "rgb(55, 55, 255)";
		gameScene.addChild(sign);

	gameScene.addChild(makeSelect('test things', 150));
	///---Add Game Objects to scene---///
///---Add Game Scene Objects---///

///Game Inputs///
	gameScene.addEventListener(Event.LEFT_BUTTON_DOWN, function(){
		paddle.x -= 5;
	});
	gameScene.addEventListener(Event.RIGHT_BUTTON_DOWN, function(){
		paddle.x += 5;
	});

	gameScene.addEventListener(Event.TOUCH_START, function(evt){
		paddle.x = evt.localX - 75;
	});
	gameScene.addEventListener(Event.TOUCH_MOVE, function(evt){
		paddle.x = evt.localX - 75;
	});
///---Game Inputs---///

game.replaceScene(gameScene);
}