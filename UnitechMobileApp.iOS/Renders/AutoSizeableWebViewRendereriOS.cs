using UIKit;
using UnitechMobileApp.iOS.Renders;
using UnitechMobileApp.mvvm.Schedule.Accordion;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AutoSizeableWebView), typeof(AutoSizeableWebViewRendereriOS))]
namespace UnitechMobileApp.iOS.Renders
{
    public class AutoSizeableWebViewRendereriOS : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            Delegate = new AutoSizeableWebViewDelegate(this);
        }
    }

    public class AutoSizeableWebViewDelegate : UIWebViewDelegate
    {
        AutoSizeableWebViewRendereriOS webViewRenderer;

        public AutoSizeableWebViewDelegate(AutoSizeableWebViewRendereriOS _webViewRenderer = null)
        {
            webViewRenderer = _webViewRenderer ?? new AutoSizeableWebViewRendereriOS();
        }

        public override void LoadingFinished(UIWebView webView)
        {
            var wv = webViewRenderer.Element as AutoSizeableWebView;
            if (wv.HeightRequest < 0)
            {
                wv.HeightRequest = (double)webView.ScrollView.ContentSize.Height;
                (wv.Parent.Parent as ViewCell).ForceUpdateSize();
            }
        }
    }
}