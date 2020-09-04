/**
 * Created by Administrator on 2014/11/13.
 */
function draw(id) {
    var canvas = document.getElementById(id);
    var context = canvas.getContext('2d');
    context.fillStyle = 'green';
    context.fillRect(0, 0, 800, 300);
    context.fillStyle = '#fff';
    context.strokeStyle = '#fff';
    context.font = "bold 40px '字体','字体','微软雅黑','宋体'";
    context.textBaseline = 'hanging';
    //    context.textAlign = 'start';
    context.fillText('欢迎收看麦子学院推出的', 10, 40);
    context.fillText('《HTML5+CSS3轻松入门与实战》', 40, 110);
    context.fillText('视频教程', 580, 180);
    //    context.fillText('123456789111121314151617181920212223242526272829《HTML5+CSS3轻松入门与实战》《HTML5+CSS3轻松入门与实战》《HTML5+CSS3轻松入门与实战》',0,230,800);
    //    context.strokeText('麦子学院',0,40);
}