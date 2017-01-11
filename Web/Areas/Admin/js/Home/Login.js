﻿
$(function () {
    //根据窗口宽度生成图片宽度
    var width = $(window).width();
    $(".screenbg ul img").css("width", width + "px");

    var i = 0;
    var f = new eui();

    //记住密码的初始化
    if (window.localStorage) {
        var cookie = window.localStorage.getItem("App_User");
        if (cookie !=null) {
            cookie = JSON.parse(cookie);
            $('.name input').val(cookie.sUserName);
            $('.password input').val(cookie.sPassWord);
            $('.remember input:checkbox').prop("checked",true);
        }
    }
    else {
        alert("浏览器版本太低,不支持记住密码功能!");
    }


    /*!
    * method:单击切换验证码
    * author:[汤台]
    * version:[1.0.0]
    */
    $('.codeImg img').click(function () {
        if (i > 4) {
            alert('图片验证码切换太频繁');
            return;
        }
        i++;
        $(this).attr("src", "/Admin/Home/GetImgCode/" + i + "");
    });

    /*!
    * method:后台用户登录
    * author:[汤台]
    * version:[1.0.0]
    */
    var state = true;
    $('.login input').click(function () {
        if (state) {
            state = false;
            var $this = $(this);
            $this.parent().removeClass("login").addClass("loginout");
            var sUserName = $('.name input').val().trim();
            var sPassWord = $('.password input').val().trim();
            var sImgCode = $('.code input').val().trim();
            f.post('/Admin/Home/CheckLogin',
                {
                    sUserName: sUserName,
                    sPassWord: sPassWord,
                    sImgCode: sImgCode
                },
                    function (res) {
                        //是否选中记住密码
                        if ($('.remember input:checkbox').prop("checked")) {
                            if (window.localStorage) {
                                window.localStorage.setItem("App_User", JSON.stringify({
                                    sUserName: sUserName,
                                    sPassWord: sPassWord,
                                    IsRember:true
                                }))
                            }
                            else {
                                alert("浏览器版本太低,不支持记住密码功能!");
                            }
                        }
                        else {
                            window.localStorage.removeItem("App_User");
                        }  
                        location.href = "/Admin/Home/Index";
                    },
                    function (r) {
                        alert(r.info);
                        $('.codeImg img').click();
                        $this.parent().removeClass("loginout").addClass("login");
                    });
        }
    });


        //绑定空格事件
    document.onkeydown = function (event) {
        if (event.keyCode == "13" && state==true) {
            $('.login input').click();
        }
    }
});