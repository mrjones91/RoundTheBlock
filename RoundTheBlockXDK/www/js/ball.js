///Ball///

	Ball = Class.create(Sprite, {
		initialize: function(radius){
			enchant.Sprite.call(this, radius, radius);
            this.image = game.assets['./asset/ball.png'];
			this.dx = 1.5;
			this.dy = 16;
			this.addEventListener(Event.ENTER_FRAME, this.move)
		},
        move: function() {
        if (ball.x > game.width - ball.width || ball.x < 0)
            ball.dx = - ball.dx;
        if (ball.y < 0)
            ball.dy = - ball.dy;
        if (ball.y > gameHeight || ball.x < 0 - ball.width || ball.x > game.width)
        {
            ball.x = ball.y = 0;
        }
        if (ball.intersect(paddle) && (ball.height < paddle.height))
        {
            ball.dx = 32 * ((ball.x-(paddle.x +paddle.width/2))/paddle.width);
            ball.dy = - ball.dy;
        }

            this.x += this.dx;
            this.y ++ this.dy;
        }


		
	});

    /*Old move function
    move: function() {
        if (ball.x > game.width - ball.width || ball.x < 0)
            ball.dx = - ball.dx;
        if (ball.y < 0)
            ball.dy = - ball.dy;
        if (ball.y > gameHeight || ball.x < 0 - ball.width || ball.x > game.width)
        {
            ball.x = ball.y = 0;
        }
        if (ball.intersect(paddle) && (ball.height < paddle.height))
        {
            ball.dx = 32 * ((ball.x-(paddle.x +paddle.width/2))/paddle.width);
            ball.dy = - ball.dy;
        }

            this.x += this.dx;
            this.y ++ this.dy;
        }


    */
	/*
    Old things

	var ball = new Sprite(25, 25);
	ball.dx = 1.5;
	ball.dy = 16;
	ball.image = game.assets['./asset/ball.png'];
	
	ball.addEventListener(Event.ENTER_FRAME, function () {
		if (ball.x > gameWidth - ball.width || ball.x < 0)
			ball.dx = - ball.dx;
		if (ball.y < 0)
			ball.dy = - ball.dy;
		if (ball.y > gameHeight || ball.x < 0 - ball.width || ball.x > gameWidth)
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
		//console.log(ball.dx);
		ball.x += ball.dx;
		ball.y += ball.dy;
	});


/*
Floor Enchant class example
Floor = Class.create(Sprite, {
            initialize: function(x,y){
                if (x == 0 || y == 0)
                {
                    enchant.Sprite.call(this, 1500, 198);
                    if (lastDead.id == -1)
                    {
                        this.x = 30;
                        nextBlock = 50;
                    }
                    else
                    {
                        this.x = (floors[fNum].x + floors[fNum].width) + 100;//+ Math.floor(Math.random() * 150);
                        if ((floors[fNum].x + floors[fNum].width) + 100 < 630)
                            this.x = 630;
                        nextBlock = (this.width / 3.75);
                    }
                    this.y = 300;
                }
                else
                {
                    //enchant.Sprite.call(this, x, y);
                    enchant.Sprite.call(this, Math.floor( (Math.random() * 600) + 150) , 
                    Math.floor( (Math.random() * 300) + 150) );
                    //console.log(floors[fNum - 1].x);
                    this.x = (floors[fNum].x + floors[fNum].width) + 100;//+ Math.floor(Math.random() * 150);
                    if ((floors[fNum].x + floors[fNum].width) + 100 < 630)
                        this.x = 630;
                    this.y = 360 - (this.height / 2);//Math.floor( Math.random() * 360 ) ;
                    nextBlock = (this.width / 3.75);
                    //alert(nextBlock);
                    //console.log("X Pos: " + this.x);
                    //console.log("Height: " + this.height);
                    //console.log("Y pos: " + this.y);
                }
                this.id = -1;
                lastWidth = this.width;
                lastX = this.x;

                this.image = game.assets['./content/Block.png'];
                this.addEventListener(Event.ENTER_FRAME, this.die);
                this.addEventListener(Event.ENTER_FRAME, this.move);
                //this.bonus = new Bonus(Math.floor(Math.random() * 4));
                //this.bonus.x = this.x + ' ' + (this.width / 2);
                //this.bonus.y = this.y - 50;
                //alert('at ' + this.bonus.x + this.bonus.y);
            },
            die: function(){
                if (this.x <= (0 - this.width))
                {
                    lastDead = this;
                    game.rootScene.removeChild(this);
                    floors[this.id] = {id: -1};

                    console.log(this.id + ' is dead');
                    console.log(floors[this.id]);
                    
                    if (this.id < 4)
                        currentF = this.id + 1;
                    else
                        currentF = 0;
                    //cp = currentF + 1;
                    //if (cp > 4)
                        //cp = 0;
                }
            },
            move: function(){
                this.x -= 5;
                //this.bonus.x -= 5;

            }
        });


*/