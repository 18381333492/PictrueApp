
window.alert = function (msg) {
    alert(msg);
}

window.confirm = function (msg) {
    confirm(msg);
}

function common() {

    /**前端验证对象**/
    var check = {
        //验证是否为空(去掉)
        empty:function(val){
            val = val.replace(/(^\s*)|(\s*$)/g, "");//去掉前后空格
            if(val.length==0)
                return true;
            return false;
        },
        //是否手机号码格式
        phone: function (val) {
            var regex = /^((13[0-9]|14[0-9]|15[0-9]|17[0-9]|18[0-9])\d{8})*$/;
            if (regex.exec(val))
                return true;
            return false;
        },
        //验证是否是邮箱
        email:function(val){
            var regex = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
            if (regex.test(val))
                return true;
            return false;
        },
        //验证是否是数字
        number: function (val) {
            var regex = /^[0-9]*$/;
            if (regex.test(val))
                return true;
            return false;
        },
        //验证是否是数字和字母的组合(忽略大小写)
        letter_num: function (val) {
            var regex = /^[A-Za-z0-9]+$/;
            if (regex.test(val))
                return true;
            return false;
        }
    }

    /*
    *js字符串的处理的通用对象
    * version:1.0.0
    * author:汤台
    */
    var string = {
        //去掉字符串前后空格
        trim:function (val) {
            return val.replace(/(^\s*)|(\s*$)/g, "");
        },
        //去掉开始的空格
        trimSta: function (val) {
            return val.replace(/(^\s*)/g, "");
        },
        //去掉结束的空格
        trimEnd: function (val) {
            return s.replace(/(\s*$)/g, "");
        },
        //给字符串前后添加相同字符串
        insert: function (val, str) {
            return str + val + str;
        },
        //字符串的插入(val,staIndex(开始添加的索引),str(添加的字符串))
        insert: function (val,staIndex,str) {
            var strArray = val.split("");
            if (staIndex < strArray.length) {
                strArray[staIndex] = str + strArray[staIndex];
            }
            return strArray.join("");
        }
    }


    return {
        check: check,//验证对象
        string:string
    }

}