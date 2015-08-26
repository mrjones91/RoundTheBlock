///Background///
	var Background = Class.create(Sprite, {
		initialize: function() {
			enchant.Sprite.call(this, 603, gameHeight);
			this.image = game.assets['./asset/textures/backgrounds/bgDark.jpg'];
			this.frame = 0;
		},
		next: function() {
			this.frame ++;
			try{
				loadLevel(this.frame);
			} catch(err) {
				//Set this to go to a main menu or something
				//Make a main menu or something
				loadLevel(0);
			}
		}
	});
	///---Background---///