using System.Web;
using System.Web.Optimization;

namespace Resume
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-3.3.1.intellisense.js",
                        "~/Scripts/jquery.countdown.min.js",
                        "~/Scripts/jquery.magnific-popup.min.js",
                        "~/Scripts/jquery.stellar.min.js",
                        "~/Scripts/jquery-migrate-3.0.1.min.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/main.js",
                        "~/Scripts/mediaelement-and-player.min.js",
                        "~/Scripts/owl.carousel.min.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/slick.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*", "~/Scripts/aos.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Site.css",
                      "~/Content/owl.theme.default.min.css",
                      "~/Content/owl.carousel.min.css",
                      "~/Content/mediaelementplayer.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-reboot.css",
                      "~/Content/bootstrap-grid.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/aos.css",
                      "~/Content/animate.css"));

        }
    }
}
