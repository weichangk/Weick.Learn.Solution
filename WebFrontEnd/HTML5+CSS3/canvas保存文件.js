/**
 * Created by Administrator on 2014/11/17.
 */
function draw(id) {
    var canvas = document.getElementById(id);
    var context = canvas.getContext('2d');
    context.fillStyle = "green";
    context.fillRect(0, 0, 400, 300);
    window.location = canvas.toDataURL('image/png');
}