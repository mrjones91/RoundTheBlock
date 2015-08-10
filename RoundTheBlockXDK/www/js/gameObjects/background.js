///Background///
	var Background = Class.create(Sprite, {
		initialize: function() {
			enchant.Sprite.call(this, 603, gameHeight);
			this.image = game.assets['./asset/textures/backgrounds/bgDark.jpg'];
			this.frame = 0;
		},
		next: function() {
			this.frame ++;
		}
	});
	///---Background---///