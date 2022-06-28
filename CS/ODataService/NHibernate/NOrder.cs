using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using ODataService.Models;
using System.Collections.Generic;

namespace ODataService.NHibernate
{
    public class NOrder
    {
        public virtual int Id { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual IList<NOrderDetail> OrderDetails { get; set; }
    }

    public class NOrderMap : ClassMapping<NOrder>
    {
        public NOrderMap()
        {
            Id(x => x.Id, x =>
            {
                x.Column("ID");
            });

            Property(x => x.OrderStatus);

            Bag(x => x.OrderDetails, map =>
            {
                map.Key(k => k.Column("OrderID"));
            }, action => action.OneToMany());

            Table("Orders");
        }
    }
}
