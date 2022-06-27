using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System.Collections.Generic;

namespace ODataService.NHibernate
{
    public class NProduct
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal UnitPrice { get; set; }

        public virtual IList<NOrderDetail> OrderDetails { get; set; }
    }

    public class NProductMap : ClassMapping<NProduct>
    {
        public NProductMap()
        {
            Id(x => x.Id, x =>
            {
                x.Column("ProductID");
            });

            Property(x => x.Name, x => {
                x.Column("ProductName");
            });

            Property(x => x.UnitPrice, x =>
            {
                x.Column("UnitPrice");
                x.Type(NHibernateUtil.Currency);
            });

            Bag(x => x.OrderDetails, map =>
            {
                map.Key(k => k.Column("OrderDetailID"));
            }, action => action.OneToMany());

            Table("Products");
        }
    }
}
