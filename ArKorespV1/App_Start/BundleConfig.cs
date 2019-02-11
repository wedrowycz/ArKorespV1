using System.Web;
using System.Web.Optimization;

namespace ArKorespV1
{
    /// <summary>
    /// application's standard bundle config
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Register bundle method, automatically generated
        /// </summary>
        /// <param name="bundles">application's bundle object</param>        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // gotowe do produkcji, użyj narzędzia do kompilowania ze strony https://modernizr.com, aby wybrać wyłącznie potrzebne testy.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
