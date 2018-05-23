using System.Web;
using System.Web.Optimization;

namespace Pro.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            //layer toastr

            //js 插件
            bundles.Add(new ScriptBundle("~/bundles/layerToastr").Include(
                      "~/Content/proset/layer/layer.js",
                      "~/Content/proset/toastr/toastr.js"));

            //css 样式
            bundles.Add(new StyleBundle("~/Content/csslayerToastr").Include(
                       "~/Content/proset/layer/skin/default/layer.css",
                      "~/Content/proset/toastr/toastr.css"));


            //bootstrap js 插件
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/js/hhl.js",
                       "~/Scripts/js/Common.js",
                      "~/Scripts/respond.js"));

            //bootstarpt css 样式
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/font-awesome.css",    //字体
                       "~/Content/PagedList.css"));  //分页


            // site css 样式
            bundles.Add(new StyleBundle("~/Content/site").Include(
                      "~/Content/Site.css"));

            // style css 样式
            bundles.Add(new StyleBundle("~/Content/style").Include(
                      "~/Content/style.css"));

            //angular js 插件
            bundles.Add(new ScriptBundle("~/bundles/angularJS").Include(
                      "~/Scripts/js/angular.js",
                      "~/Content/css/jquery.pagination.js",
                      "~/Scripts/js/angular-animate.js"));

            //ueditor js 插件
            bundles.Add(new ScriptBundle("~/bundles/editorJs").Include(
                      "~/Content/ueditor/ueditor.config.js",
                      "~/Content/ueditor/ueditor.all.min.js"));

            //ueditor css 样式
            bundles.Add(new StyleBundle("~/Content/uedtorCss").Include(
                      "~/Content/ueditor/themes/iframe.css",
                      "~/Content/ueditor/themes/default/css/ueditor.css"));

            //widget css样式
            bundles.Add(new StyleBundle("~/Content/widget").Include(
                     "~/Content/widget/widget.css"));


            //widget js 插件
            bundles.Add(new ScriptBundle("~/bundles/widget").Include(
                     "~/Content/widget/widget.js"));


        }
    }
}
