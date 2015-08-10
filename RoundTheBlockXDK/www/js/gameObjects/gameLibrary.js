//Call functionality of 
var gameObjectLoad = function() {

	Block.prototype.die = function() {
		if (this.intersect(ball))
			{
				game.rootScene.removeChild(this);
			}
	};

	Ball.prototype.move = function() {
		if (this.x > game.width - this.width || this.x < 0)
            this.dx = - this.dx;
        if (this.y < 0)
            this.dy = - this.dy;
        if (this.y > gameHeight || this.x < 0 - this.width || this.x > game.width)
        {
            this.x = this.y = 0;
            background.next();
        }
        if (this.intersect(paddle) && (this.height < paddle.height))
        {
            this.dx = 32 * ((this.x-(paddle.x +paddle.width/2))/paddle.width);
            this.dy = - this.dy;
        }

            this.x += this.dx;
            this.y += this.dy;
	};
}