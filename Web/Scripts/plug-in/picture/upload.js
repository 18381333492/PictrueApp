





function upload() {
    
    var element;
        //默认参数
    var defaults = {
        url: "/HandleProgram/PictureUpload.ashx",
        width:120,
        height:120,
    }

    //创建图片上传插件
    function create(id, option) {
        defaults = $.extend(defaults, option);
        element = document.getElementById(id);
        init();
    }

    //初始化
    function init(id) {
        var dd = $(element).load("/Scripts/plug-in/picture/style.html",
            function (data) {
                $(element).html("");
                data = data.trim();
                $(element).append(data);//追加html
                     //初始化图片路径
                if($(element).next().val()!=""){
                    $(element).find("img").attr("src", $(element).next().val())
                }
                    //设置图片的大小
                $(element).find("img").height(defaults.height);
                $(element).find("img").width(defaults.height);
                bingEvent();

        });
    }

    //绑定事件
    function bingEvent() {
        $(element).find("img").on("click", function () {
            $(element).find("input").click();
        });
        $(element).find("input").on("change", function () {
            if ($(this).val() != "") {   
                Up();
            }
        });
    }

    //上传图片
    function Up() {
             //利用easyui的表单提交上传图片
        $(element).find("form").form('submit', {
            url: defaults.url,
            //queryParams: { path: option.path },
            success: function (data) {
                data = JSON.parse(data);
                if (data.error == 0) {
                    $(element).find("img").attr("src", data.url);
                    $(element).next().val(data.url);
                } else {
                    alert(data.message);
                }
            }
        });
    }

    return {
        create: create,
    }
}
