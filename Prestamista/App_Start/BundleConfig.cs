using System.Web;
using System.Web.Optimization;

namespace Prestamista
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //  Plantilla chain basica
            bundles.Add(new StyleBundle("~/Style/plantillaBasica").Include(
                "~/Scripts/modernizr-*",      
                "~/Content/theme_chain/css/style.default.css"               
                      ));
            bundles.Add(new ScriptBundle("~/JS/plantillaBasica").Include(
                "~/Content/theme_chain/js/jquery-1.11.1.min.js",
                "~/Content/theme_chain/js/jquery-migrate-1.2.1.min.js",
                "~/Content/theme_chain/js/bootstrap.min.js",
                "~/Content/theme_chain/js/modernizr.min.js",
                "~/Content/theme_chain/js/pace.min.js",
                "~/Content/theme_chain/js/retina.min.js",
                "~/Content/theme_chain/js/jquery.cookies.js",
                "~/Content/theme_chain/js/custom.js"
                //"~/Content/theme_chain/js/jquery-1.11.1.min.js",
                //"~/Content/theme_chain/js/jquery-1.11.1.min.js",
                      ));
            bundles.Add(new StyleBundle("~/Style/CorreccionPlantilla").Include(
                "~/Content/theme_chain/css/style.default.css"

                      //"~/Content/site.css"
                      ));
            //c:\users\secretaria_ cel\documents\visual studio 2013\Projects\Prestamista\Prestamista\Content\theme_chain\css\style.default.css
//c:\users\secretaria_ cel\documents\visual studio 2013\Projects\Prestamista\Prestamista\Content\theme_chain\js\jquery-1.11.1.min.js

        }
    }
}
