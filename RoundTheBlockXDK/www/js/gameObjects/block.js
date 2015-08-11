Block = Class.create(Sprite, {
		initialize: function(frm, row, cell){
			enchant.Sprite.call(this, 65, 34);
			this.image = game.assets['./asset/blocks.png'];
			this.frame = frm;
			switch (row){
				case 'a':
				this.y = 225;
				break;
				case 'b':
				this.y = 259;
				break;
				case 'c':
				break;
				case 'd':
				break;
				case 'e':
				break;
				case 'f':
				break;
				case 'g':
				break;
			};
			
			this.x = this.width * cell;
			
			if (this.intersect(blocks))
			{
				console.log('something');
			}
			this.addEventListener(Event.ENTER_FRAME, this.die);
		}
	});