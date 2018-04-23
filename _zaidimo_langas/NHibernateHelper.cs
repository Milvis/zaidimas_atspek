using _zaidimo_langas;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace _zaidimo_langas
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=zaidimo_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                              .ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<gamers>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
