// main.js
// main driver for assignment 1
//
// AUTHOR: Rushil Kohli
// DATE: 2022-02-03

// main entry point
document.addEventListener("DOMContentLoaded", main);
function main() 
{
    initWebGL("webglView");
};

var titleDebugger = "DeBugger";
var titleCelestia = "Celestia";
var titleTotoro = "Totoro"
var titleLuckyCat = "Lucky Cat"
var titleBeethoven = "Beethoven"

let image1 = document.getElementById("thumb_debugger");
image1.addEventListener("click", function changeTitle(newTitle)
{
    document.getElementById("title").innerHTML = titleDebugger;
    loadModelByName("DeBugger");
}, false);

let image2 = document.getElementById("thumb_celestia");
image2.addEventListener("click", function changeTitle(newTitle)
{
    document.getElementById("title").innerHTML = titleCelestia;
    loadModelByName("Celestia");
}, false);

let image3 = document.getElementById("thumb_totoro");
image3.addEventListener("click", function changeTitle(newTitle)
{
    document.getElementById("title").innerHTML = titleTotoro;
    loadModelByName("Totoro");
}, false);

let image4 = document.getElementById("thumb_luckycat");
image4.addEventListener("click", function changeTitle(newTitle)
{
    document.getElementById("title").innerHTML = titleLuckyCat;
    loadModelByName("Lucky Cat");
}, false);

let image5 = document.getElementById("thumb_beethoven");
image5.addEventListener("click", function changeTitle(newTitle)
{
    document.getElementById("title").innerHTML = titleBeethoven;
    loadModelByName("Beethoven");
}, false);

let resetButton = document.getElementById("resetCamera");
resetButton.addEventListener("click", function resetImage()
{
    resetCamera();
}, false);

let toggle_texture = document.getElementById("texture");
toggle_texture.addEventListener("change", function toggle_Texture()
{
    if(this.checked)
    {
        enableTexture();
    }
    else {
        disableTexture();
    }
}, false);

let toggle_spin = document.getElementById("spin");
toggle_spin.addEventListener("change", function toggle_Spin()
{
    if(this.checked)
    {
        toggleSpin(toggleSpin);
    }
    else {
        disableSpin();
    }
}, false);

window.addEventListener("keydown", function startShiftCamera(x,y) {
    
});


/*startShiftCamera(1,0);
startShiftCamera(-1,0); 
startShiftCamera(0,1);
startShiftCamera(0,-1);
startZoomCamera(1);
startZoomCamera(-1);*/

