// Write your JavaScript code.
// HTMLの読み込みが完了したら動く
//$(function () {
//    // 出退勤記録ボタンが押された時
//    $('.RecBtn').on('click', function () {
//        //ajax処理
//        $.ajax({
//            url: '/Kintai/Rec',
//            type: 'POST',
//            data: {
//                // 選択しているボタンの要素を取得
//                'btn': $(this).data('btn')
//            }
//        })
//            // Ajaxリクエストが成功した時発動
//            .done(function (data) {
//                if (data.status === "success") {
//                    // 処理成功の場合はフォームに取得したパーキング情報から各情報をセット
//                }
//            })

//            // Ajaxリクエストが失敗した時発動
//            .fail(function (data) {
//                alert('Ajaxリクエストエラーが発生しました');
//            })

//    });
//});