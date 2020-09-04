/**
 * Created by Administrator on 2014/11/10.
 */
function draw(id) {
    var canvas = document.getElementById(id);
    var context = canvas.getContext('2d');
    context.fillStyle = "green";
    context.strokeStyle = "#fff";
    context.lineWidth = 5;
    context.fillRect(0, 0, 400, 300);
    context.strokeRect(50, 50, 180, 120);
    context.strokeRect(110, 110, 180, 120);
}