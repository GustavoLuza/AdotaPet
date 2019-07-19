using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.Context
{
   public class TreinamentoContext : DbContext //FAZENDO A CLASSE HERDAR DE DBCONTEXT
    {
        public TreinamentoContext() : base("DefaultConnection") // A CLASSE BASE DBCONTEXT VAI CONECTAR NA CONNECTION STRING
        {
            
        }

        public DbSet<Cliente>Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Doenca> Doencas { get; set; }
        public DbSet<Raca> Racas { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Ong> Ongs { get; set; }

        //SOBREESCREVE A CRIAÇÃO DO BANCO
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //PARAR DE COLOCAR TABELAS NO PLURAL
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //DESABILITAR O CASCADE DELETE
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //DESABILITAR O CASCADE DELETE

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey()); //QUANDO O NOME DA CLASSE FOR SEGUIDO DE ID, VAI DEFINIR COMO PK NO BANCO
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar")); //QUANDO FOR DO TIPO STRING, VAI CONFIGURAR NO BANCO COMO VARCHAR
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100)); //TODA VEZ QUE A COLUNA DO BANCO FOR VARCHAR, VAI DEFINIR O TAMANHO COMO 100

            modelBuilder.Configurations.Add(new ClienteConfig()); //FAZENDO O BANCO SER CRIADO COM AS CONFIGURAÇÕES DEFINIDAS NA CLASSE
            modelBuilder.Configurations.Add(new EnderecoConfig()); //FAZENDO O BANCO SER CRIADO COM AS CONFIGURAÇÕES DEFINIDAS NA CLASSE
            modelBuilder.Configurations.Add(new DoencaConfig());
            modelBuilder.Configurations.Add(new RacaConfig());
            modelBuilder.Configurations.Add(new AnimalConfig());
            modelBuilder.Configurations.Add(new OngConfig());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //SOBREESCREVE O SAVECHANGES PARA VERIFICAR SE É UM CADASTRO NOVO OU ATUALIZAÇÃO, SE FOR CADASTRO NOVO, ADICIONA A DATA DO CADASTRO,
            //SE FOR ATUALIZAÇÃO, NÃO ALTERA A DATA DE CADASTRO
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
