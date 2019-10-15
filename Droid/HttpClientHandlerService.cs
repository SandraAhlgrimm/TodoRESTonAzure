using System.Net.Http;
using Android.Net;
using Javax.Net.Ssl;
using TodoREST.Droid;
using Xamarin.Android.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpClientHandlerService))]
namespace TodoREST.Droid
{
    public class HttpClientHandlerService : IHttpClientHandlerService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            return new IgnoreSSLLocalHostClientHandler();
        }

        internal class IgnoreSSLLocalHostClientHandler : AndroidClientHandler
        {
            protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
            {
                return SSLCertificateSocketFactory.GetInsecure(1000, null);
            }

            protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection)
            {
                return new IgnoreSSLLocalhostHostnameVerifier();
            }
        }

        internal class IgnoreSSLLocalhostHostnameVerifier : Java.Lang.Object, IHostnameVerifier
        {
            public bool Verify(string hostname, ISSLSession session)
            {
                if (hostname.Equals("10.0.2.2"))
                    return true;
                return false;
            }
        }
    }
}
