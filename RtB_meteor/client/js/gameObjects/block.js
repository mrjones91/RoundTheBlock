if (Meteor.isClient){

Block = Class.create(Sprite, {
		initialize: function(frm){
			enchant.Sprite.call(this, 65, 34);
			this.image = game.assets['./asset/blocks.png'];
			this.frame = frm;
			this.y = 225;
			this.addEventListener(Event.ENTER_FRAME, this.die);
		}
	});
}