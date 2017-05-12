using System.Web;
using System.Web.Optimization;

namespace WebIluminaMVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/smartadmin").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/demo.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/invoice.min.css",
                "~/Content/css/lockscreen.min.css",
                "~/Content/css/smartadmin-production-plugins.min.css",
                "~/Content/css/smartadmin-production.min.css",
                "~/Content/css/smartadmin-rtl.min.css",
                "~/Content/css/smartadmin-skins.min.css",
                "~/Content/css/your_style.css"
                ));

            bundles.Add(new ScriptBundle("~/scripts/smartadmin").Include(
                 "~/Scripts/app.config.js",
                 "~/Scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                 "~/Scripts/bootstrap/bootstrap.min.js",
                 "~/Scripts/notification/SmartNotification.min.js",
                 "~/Scripts/smartwidgets/jarvis.widget.min.js",
                 "~/Scripts/plugin/jquery-validate/jquery.validate.min.js",
                 "~/Scripts/plugin/masked-input/jquery.maskedinput.min.js",
                 "~/Scripts/plugin/select2/select2.min.js",
                 "~/Scripts/plugin/bootstrap-slider/bootstrap-slider.min.js",
                 "~/Scripts/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                 "~/Scripts/plugin/msie-fix/jquery.mb.browser.min.js",
                 "~/Scripts/plugin/fastclick/fastclick.min.js",
                 "~/Scripts/app.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/full-calendar").Include(
                "~/Scripts/plugin/moment/moment.min.js",
                "~/Scripts/plugin/fullcalendar/jquery.fullcalendar.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/charts").Include(
                "~/Scripts/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
                "~/Scripts/plugin/sparkline/jquery.sparkline.min.js",
                "~/Scripts/plugin/morris/morris.min.js",
                "~/Scripts/plugin/morris/raphael.min.js",
                "~/Scripts/plugin/flot/jquery.flot.cust.min.js",
                "~/Scripts/plugin/flot/jquery.flot.resize.min.js",
                "~/Scripts/plugin/flot/jquery.flot.time.min.js",
                "~/Scripts/plugin/flot/jquery.flot.fillbetween.min.js",
                "~/Scripts/plugin/flot/jquery.flot.orderBar.min.js",
                "~/Scripts/plugin/flot/jquery.flot.pie.min.js",
                "~/Scripts/plugin/flot/jquery.flot.tooltip.min.js",
                "~/Scripts/plugin/dygraphs/dygraph-combined.min.js",
                "~/Scripts/plugin/chartjs/chart.min.js",
                "~/Scripts/plugin/highChartCore/highcharts-custom.min.js",
                "~/Scripts/plugin/highchartTable/jquery.highchartTable.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/datatables").Include(
                "~/Scripts/plugin/datatables/jquery.dataTables.min.js",
                "~/Scripts/plugin/datatables/dataTables.colVis.min.js",
                "~/Scripts/plugin/datatables/dataTables.tableTools.min.js",
                "~/Scripts/plugin/datatables/dataTables.bootstrap.min.js",
                "~/Scripts/plugin/datatable-responsive/datatables.responsive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/jq-grid").Include(
                "~/Scripts/plugin/jqgrid/jquery.jqGrid.min.js",
                "~/Scripts/plugin/jqgrid/grid.locale-en.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/forms").Include(
                "~/Scripts/plugin/jquery-form/jquery-form.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/smart-chat").Include(
                "~/Scripts/smart-chat-ui/smart.chat.ui.min.js",
                "~/Scripts/smart-chat-ui/smart.chat.manager.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/vector-map").Include(
                "~/Scripts/plugin/vectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Scripts/plugin/vectormap/jquery-jvectormap-world-mill-en.js"
                ));

        }
    }
}
