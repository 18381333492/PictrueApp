
/*
*
*Easy UI 插件的重写js
*
*/

void function () {
    $.extend($.fn.textbox.defaults, {
        height: 30,
        width: 200,
        required: true,
        missingMessage:'该字段为必填项!'
    });

    $.extend($.fn.numberbox.defaults, {
        height: 30,
        width: 200,
        required: true,
        missingMessage: '该字段为必填项!'
    });

    $.extend($.fn.combobox.defaults, {
        height: 30,
        width: 200,
        panelHeight:'auto'
    });

    /**
    *重写分页控件的显示
    */
    $.extend($.fn.pagination.defaults, {
        beforePageText: '第',//页数文本框前显示的汉字 
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录  共{total}条记录',
    });

    /**
    *重写datagrid的onLoadSuccess事件
    */
    $.extend($.fn.datagrid.defaults, {
        onLoadSuccess: function () {
            window.closeloading();
        },
    });

    $.extend($.fn.treegrid.defaults, {
        onLoadSuccess: function () {
            window.closeloading();
        },
    });

    $.extend($.fn.tree.defaults, {
        onLoadSuccess: function () {
            window.closeloading();
        },
    });
}()