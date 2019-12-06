<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="Pro.Web.Import" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/Scripts/jquery.form.js"></script>
   
    <script type="text/javascript">

        function submitForm() {
            //layer.msg("进入调试");
            //hhl.ajax('/AdminWorkArea/Handler/ImportCustomer.ashx', $("form").serialize(), function (result) {
            //    console.log(result);
            //}, 1);


        }

        function submitForm() {
            $("#btnPost").click();
        }


        $(function () {
      

            $("#btnPost").click(function () {

                alert("11");
                //var path = $("input[type='file']").val();

                //if (path == "") {
                //    hhl.notify.info("请选择上传文件！", "提示");
                //    return false;
                //}

                //var fileEx = path.substring(path.lastIndexOf('.') + 1);
                //console.log(path + "||" + fileEx);
                //if (fileEx != "xls" && fileEx != "xlsx") {
                //    hhl.notify.info(fileEx + "文件类型不对！只能导入xls或xlsx格式的文件", "提示");
                //    return false;
                //}

                //$("#form1").ajaxSubmit({
                //    url: "/AdminWorkArea/Handler/ImportCustomer.ashx",
                //    type: "post",
                //    dataType: 'json',
                //    enctype: "multipart/form-data",
                //    success: function (result) {
                //        if (result.IsSuccess) {
                //            hhl.notify.success(result.Message, "提示");

                //            setTimeout(function () {
                //                var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
                //                parent.layer.close(index);
                //            }, 1200)

                //        } else {
                //            hhl.notify.error(result.Message, "提示");
                //        }
                //    },
                //    error: function (data) {
                //        hhl.notify.error("异常错误", "警告");
                //    }
                //});
            });
        });



    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="panel">
        <div class="panel-body">
            <div class="form-group">
                <div class="progress progress-striped">
                    <div class="progress-bar progress-bar-danger" style="width: 33.3%">
                        <label>第一步：下载模版</label>
                    </div>
                    <div class="progress-bar progress-bar-warning" style="width: 33.3%">
                        <label>第二步：上传Excel文件</label>
                    </div>
                    <div class="progress-bar progress-bar-success" style="width: 33.3%">
                        <label>第三步：导入客户</label>
                    </div>
                </div>
            </div>
            <div class="form-group text-center">
                <label class="control-label col-sm-7" style="font-weight: normal; font-size: 14px;">模版格式：导入客户模版如下图,请保持一致</label>
                <div class="col-sm-1"></div>
                <div class="col-sm-2"><a class="btn btn-info" style="font-weight: bold;" href="/Template/导入客户模版.xlsx">下载模版</a></div>
            </div>
            <div class="form-group">
                <div class="text-center">
                    <img src="/Template/导入客户模版.png" />
                </div>
            </div>
            <div class="form-group"></div>
            <div class="col-sm-3"></div>

            <div class="form-group">
                <div class="text-center">
                    <label class="col-sm-2">请选择导入文件:</label>
                    <div class="col-sm-1">
                        <input type="file" id="upFile" name="upFile" class="btn btn-success" />
                    </div>
                </div>
            </div>

            <div class="text-center hide">
                <input type="submit" value="Form提交" class="btn btn-primary btn-sm" />
                <input type="button" id="btnPost" value="button提交" class="btn btn-info" />

                <input type="hidden" id="hideEmployee" name="hideEmployee" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
