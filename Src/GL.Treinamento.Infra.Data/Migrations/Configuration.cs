using System.Data.Entity.Migrations;

namespace GL.Treinamento.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GL.Treinamento.Infra.Data.Context.TreinamentoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.TreinamentoContext context)
        {
            
        }
    }
}
