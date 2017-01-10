///*
//*
//* @description:对js扩展的封装
//* @author:tangtai
//* @time:2016-09-19
//* 
//*/

function extend() {

    /*
    * 给字符串前后添加单引号
    * @author [汤台]
    * @version 1.0.0
    * @param   String(数据源)
    * @return {String}
    */
    this.AddQuote = function (str) {
        try {
            return "'" + str + "'";
        }
        catch (e) {
            alert(e.message);
        }
    }

    /*
    * 获取datagrid选择行的ID集合(逗号隔开)
    * @author [汤台]
    * @version 1.0.0
    * @param   array(选择行的数据集合数组)
    * @return {String}
    */
    this.GetIds = function (array) {
        try {
            var Ids = [];
            $(array).each(function () {
                var $this = this;
                Ids.push(new extend().AddQuote($this.ID));
            });
            return Ids.join();
        } catch (e) {
            alert(e.message);
        }
    }

    /*
    * 获取html标签数组val集合(逗号隔开)
    * @author [汤台]
    * @version 1.0.0
    * @param   array(html标签数据集合数组)
    * @return {String}
    */
    this.GetValue = function (array) {
        try {
            var data = [];
            $(array).each(function () {
                var $this = this;
                data.push($($this).val());
            });
            return data.join();
        } catch (e) {
            alert(e.message);
        }
    }


    /*
    * 获取html标签数组attr值集合(逗号隔开)
    * @author [汤台]
    * @version 1.0.0
    * @param   array(html标签数据集合数组),attrName(属性名)
    * @return {String}
    */
    this.GetAttr = function (array,attrName) {
        try {
            var data = [];
            $(array).each(function () {
                var $this = this;
                data.push($($this).attr(attrName));
            });
            return data.join();
        } catch (e) {
            alert(e.message);
        }
    }

    /*
    * 将js的serializeArray()得到的数组转化为Js对象
    * @author [汤台]
    * @version 1.0.0
    * @param   array
    * @return {Object}
    */
    this.ToFromObject = function (array) {
        var obj = {};
        for (var i = 0; i < array.length; i++) {
            var key = array[i]["name"];
            var value = array[i]["value"];
            obj[key] = value;
        }
        return obj;
    }
}
