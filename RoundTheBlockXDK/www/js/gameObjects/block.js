Block = Class.create(Sprite, {
		initialize: function(frm, row, cell){
			enchant.Sprite.call(this, 65, 34);
			this.baseY = 225;
			this.image = game.assets['./asset/blocks.png'];
			if (frm >= 0 && frm <= 7) {
				this.frame = frm;
			}
			else  {
				this.frame = 8;
			}
			this.y = this.baseY;
			if (row == 0) {
				this.y = this.baseY;
			} else {
				this.y = this.baseY + (this.height * row);
			}
			
			this.x = this.width * cell;
			
			this.addEventListener(Event.ENTER_FRAME, this.die);
		},
		destroy: function() {
			gameScene.removeChild(this);
		}
	});