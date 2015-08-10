
	var Paddle = Class.create(Sprite, {
	initialize: function(width, height) {
	enchant.Sprite.call(this, width, height);
	this.image = game.assets['./asset/arkPaddle.png'];
	this.frame = [0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3];
	this.y = 800;
	}
});

// new Sprite(128, 30);
// 	paddle.y = 800;
// 	paddle.image = game.assets['./asset/arkPaddle.png'];
// 	//paddle.frame = [8, 9, 10, 11];
// 	paddle.frame = [0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3];