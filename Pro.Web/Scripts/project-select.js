/**
 * Bootstrap Select
 * @desc    这是一个基于 bootstrap x下拉框上。
 * @author  renxia <lzwy0820#qq.com>
 * @github  https://github.com/lzwme/bootstrap-suggest-plugin.git
 * @since   2018-09-05
 *===============================================================================
 *  * 一、功能说明：
 * 1. 搜索方式：从 data.value 的所有字段数据中查询 keyword 的出现，或字段数据包含于 keyword 中
 * 2. 支持单关键的输入搜索建议，
 * 3. 支持按 data 数据搜索、按  URL 请求搜索和按首次请求URL数据并缓存搜索三种方式【getDataMethod】
 * 4. 单关键字会设置输入框内容和 data-id 两个值，以 indexId 和 indexKey 取值 data 数据的次序为准；多关键字不支持 data-id 设置
 * 5. 对于单关键字支持，当 data-id 为空时，输入框会添加背景色警告
 *
 * 二、使用参考：
 * 1. 引入 jQuery、bootstrap.min.css、bootstrap.min.js
 * 2. 引入插件js:bootstrap-select.min.js
 * 3. 使用方法
 *
            $('#select1').bootstrapSelect({
                url: '/Student/GetCompanyInfo',
                data: [],
                valueField: 'CompanyID',
                textField: 'CompanyName',
            });
 * 4. 方法参考：
 *  全选： $('.selectpicker').selectpicker('selectAll');

 *反选： $('.selectpicker').selectpicker('deselectAll');

 *适应手机模式： $('.selectpicker').selectpicker('mobile');

 *组件禁用：

 *$('.disable-example').prop('disabled', true);
 *$('.disable-example').selectpicker('refresh');
 *组件启用：

 *$('.disable-example').prop('disabled', false);
 *$('.disable-example').selectpicker('refresh');
 *组件销毁：

 *$('.selectpicker').selectpicker('destroy');
 *===============================================================================

 ********************************************************************************/

function mutileControl(controls, url, value, text) {
    for (var i = 0; i < controls.length; i++) {
        var control = controls[i];
        $('#' + control).bootstrapSelect({
            url: url,
            data: [],
            valueField: value,
            textField: text,
        });
    }
}

(function ($) {
    //1.定义jquery的扩展方法bootstrapSelect
    $.fn.bootstrapSelect = function (options, param) {

        if (typeof options == 'string') {
            return $.fn.bootstrapSelect.methods[options](this, param);
        }
        //2.将调用时候传过来的参数和default参数合并
        options = $.extend({}, $.fn.bootstrapSelect.defaults, options || {});
        //3.添加默认值
        var target = $(this);
        if (!target.hasClass("selectpicker")) target.addClass("selectpicker");
        target.attr('valuefield', options.valueField);
        target.attr('textfield', options.textField);
        target.empty();
        var option = $('<option></option>');
        option.attr('value', '');
        option.text(options.placeholder);
        target.append(option);
        //4.判断用户传过来的参数列表里面是否包含数据data数据集，如果包含，不用发ajax从后台取，否则否送ajax从后台取数据
        if (options.data.length > 0) {
            init(target, options.data);
        }
        else {
            //var param = {};
            if (options.param) {
                options.onBeforeLoad.call(target, options.param);
            }
            if (!options.url) return;
            $.post(options.url, options.param, function (data) {
                init(target, data);
            });
        }

        function init(target, data) {
            $.each(data, function (i, item) {
                var option = $('<option></option>');
                option.attr('value', item[options.valueField]);
                option.text(item[options.textField]);
                target.append(option);
            });
            //options.onLoadSuccess.call(target);
        }
        target.unbind("change");
        target.on("change", function (e) {
            if (options.onChange)
                return options.onChange(target.val());
        });
    }

    //5.如果传过来的是字符串，代表调用方法。
    $.fn.bootstrapSelect.methods = {
        getValue: function (jq) {
            return jq.val();
        },
        setValue: function (jq, param) {
            jq.val(param);
        },
        load: function (jq, url) {
            $.getJSON(url, function (data) {
                jq.empty();
                var option = $('<option></option>');
                option.attr('value', '');
                option.text('请选择');
                jq.append(option);
                $.each(data, function (i, item) {
                    var option = $('<option></option>');
                    option.attr('value', item[jq.attr('valuefield')]);
                    option.text(item[jq.attr('textfield')]);
                    jq.append(option);
                });
            });
        }
    };

    //6.默认参数列表
    $.fn.bootstrapSelect.defaults = {
        url: null,
        param: null,
        data: null,
        valueField: 'value',
        textField: 'text',
        placeholder: '请选择',

    };

    //初始化
    $(".selectpicker").each(function () {
        var target = $(this);
        target.attr("title", $.fn.select.defaults.placeholder);
        target.selectpicker();
    });
})(jQuery);