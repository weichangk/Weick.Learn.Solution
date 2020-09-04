/**
 * Created by Administrator on 2014/11/22.
 */
var context;
var width, height;
var i;
function draw(id) {
    var canvas = document.getElementById(id);
    context = canvas.getContext('2d');
    width = canvas.width;
    height = canvas.height;
    setInterval(painting, 100);
    i = 0;
}
function painting() {
    //    context.fillStyle = "green";
    //    context.fillRect(i,i,10,10);
    //    context.fillRect(400-i,400-i,10,10);
    //    context.fillRect(400-i,400-i,10,10);
    //    context.fillRect(0,400-i,10,10);
    context.fillStyle = "green";
    context.fillRect(0, 0, width, height);
    context.clearRect(10, 10, width, height);
    context.fillStyle = "green";
    context.fillRect(i, 20, 10, 10);
    i = i + 20;
}