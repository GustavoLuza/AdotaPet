using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GL.Treinamento.UI.Site.Startup))]
namespace GL.Treinamento.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
