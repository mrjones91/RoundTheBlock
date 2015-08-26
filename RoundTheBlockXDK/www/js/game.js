enchant();

///Global Variables / Game Objects ///
var gameWidth = 588;
var gameHeight = 940;
var game = new Core(gameWidth, gameHeight);
var background, ball, paddle, blocks;

///Scenes
var splashScene = new Scene();
var mainMenuScene = new Scene();
var gameScene = new Scene();
var creditScene = new Scene();
var optionScene = new Scene();

game.preload('./asset/textures/backgrounds/bgDark.jpg', './asset/arkPaddle.png', './asset/ball.png', './asset/blocks.png', './asset/paddle.png');

//can likely remove due to refactor of background
//var frame = 0, bgf = 0;
var level = 0;

game.onload = function(){



//Splash screen for logos
///Add Splash Scene objects///

///---Add Splash Scene objects---///

//Main Menu Scene///
loadMainMenu();
///Add Main Scene objects///

///---Add Main Scene objects---///

// loadGameScene();


//Credits + donation things
//Options

// var scene = new Scene();
// sign.x = 200;
// scene.addChild(sign);
//game.pushScene(scene);
//game.popScene();




};//End game.onload

game.start();