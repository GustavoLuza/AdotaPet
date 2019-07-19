using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Domain.Services;
using GL.Treinamento.Infra.Data.Context;
using GL.Treinamento.Infra.Data.Repository;
using GL.Treinamento.Infra.Data.UnitOfWork;
using N.Treinamento.Application;
using N.Treinamento.Application.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.CrossCutting.IOC
{
   public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //APLICAÇÃO
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IPainelAdministrativoAppService, PainelAdministrativoAppService>(Lifestyle.Scoped);
            container.Register<IAspNetUsersAppService, AspNetUsersAppService>(Lifestyle.Scoped);
            container.Register<IDoencaAppService, DoencaAppService>(Lifestyle.Scoped);
            container.Register<IRacaAppService, RacaAppService>(Lifestyle.Scoped);
            container.Register<IAnimalAppService, AnimalAppService>(Lifestyle.Scoped);
            container.Register<IOngAppService,OngAppService>(Lifestyle.Scoped);
            //container.Register<IMantimentoAppService, mantimento>(Lifestyle.Scoped);

            //DOMINIO
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IPainelAdministrativoService, PainelAdministrativoService>(Lifestyle.Scoped);
            container.Register<IAspNetUsersService, AspNetUsersService>(Lifestyle.Scoped);
            container.Register<IDoencaService, DoencaService>(Lifestyle.Scoped);
            container.Register<IRacaService, RacaService>(Lifestyle.Scoped);
            container.Register<IAnimalService, AnimalService>(Lifestyle.Scoped);
            container.Register<IOngService, OngService>(Lifestyle.Scoped);

            //DADOS
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IPainelAdministrativoRepository, PainelAdministrativoRepository >(Lifestyle.Scoped);
            container.Register<IAspNetUsersRepository, AspNetUsersRepository>(Lifestyle.Scoped);
            container.Register<IDoencaRepository, DoencaRepository>(Lifestyle.Scoped);
            container.Register<IRacaRepository, RacaRepository>(Lifestyle.Scoped);
            container.Register<IAnimalRepository, AnimalRepository>(Lifestyle.Scoped);
            container.Register<IOngRepository, OngRepository>(Lifestyle.Scoped);
            container.Register<IUnityOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<TreinamentoContext>(Lifestyle.Scoped);
        }
    }
}
