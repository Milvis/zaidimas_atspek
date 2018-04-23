using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _zaidimo_langas
{
    class gamersMap : ClassMap<gamers>
    {
        public gamersMap()
        {
            Id(x => x.GamerID);
            Map(x => x.FirstName);
            Map(x => x.Points);
            Table("zaidimoDB");
        }
    }
}



