using System.Web;
using System.Web.Optimization;
using System.Collections.Generic;
using System.Linq;

namespace Electronic_Store_Web_Online
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundle)
        {
            //--Add style CSS to bundle
            bundle.Add(new StyleBundle("~/bundles/Css").Include(
                                                                        "~/Content/bootstrap.css",
                                                                        "~/Content/style.css",
                                                                        "~/Content/fasthover.css",
                                                                        "~/Content/popuo-box.css",
                                                                        "~/Content/font-awesome.css",
                                                                        "~/Content/jquery.countdown.css"));
            //--Add style Scripts to bundle
            bundle.Add(new ScriptBundle("~/bundles/JScripts").Include("~/Scripts/jquery.min.js",
                                                                      "~/Scripts/bootstrap-3.1.1.min.js"));
            bundle.Add(new ScriptBundle("~/bundles/CartScripts").Include("~/Scripts/minicart.js"));
        }
    }
}
