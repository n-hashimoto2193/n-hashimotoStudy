// Write your JavaScript code.
function set2fig(num) {
    // 桁数が1桁だったら先頭に0を加えて2桁に調整する
    var ret;
    if (num < 10) { ret = "0" + num; }
    else { ret = num; }
    return ret;
}

function showClock2() {
    var nowTime = new Date();
    var nowYear = nowTime.getFullYear();	// 年
    var nowMonth = set2fig(nowTime.getMonth() + 1);	// 月
    var nowDate = set2fig(nowTime.getDate());	// 日

    var nowHour = set2fig(nowTime.getHours());	// 時間
    var nowMin = set2fig(nowTime.getMinutes());	// 分
    var nowSec = set2fig(nowTime.getSeconds());	// 秒

    var dayOfWeekStr = ["日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日"];	// 曜日(日本語表記)
    var dayOfWeek = nowTime.getDay();	// 曜日(数値)


    var msg = nowYear + "/" + nowMonth + "/" + nowDate + " " + nowHour + ":" + nowMin + ":" + nowSec + "  (" + dayOfWeekStr[dayOfWeek] + ")"; 
    document.getElementById("RealtimeClockArea2").innerHTML = msg;
}
setInterval('showClock2()', 1000);