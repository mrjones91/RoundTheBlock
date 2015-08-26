var loadMainMenu = function() {
	background = new Background();
	mainMenuScene.addChild(background);
	var gameButton = new Block(1, 1, 1);
	gameButton.x = 0;
	gameButton.y = 0;
	mainMenuScene.addEventListener(Event.TOUCH_START, function(evt) {
	//if (evt.localX < 250)
	// console.log('gb.X = ' + gameButton.x + '\ngb.Y = ' + gameButton.y);
	// console.log('gb.W = ' + gameButton.width + '\ngb.H = ' + gameButton.height);
		if (evt.localX >= gameButton.x){
			if (evt.localX <= (gameButton.x + gameButton.width) ) {
				if (evt.localY >= gameButton.y) {
					if (evt.localY <= (gameButton.y + gameButton.height)) {
						loadGameScene();
					}
				}
			}
		}
	})
	mainMenuScene.addChild(gameButton);
	game.pushScene(mainMenuScene);
}