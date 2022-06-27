using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace ODataService.NHibernate
{
    public class NOrderDetail
    {
        public virtual int Id { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual short Quantity { get; set; }

        public virtual NOrder Order { get; set; }
        public virtual NProduct Product { get; set; }
    }

    public class NOrderDetailMap: ClassMapping<NOrderDetail>
    {
        public NOrderDetailMap()
        {
            Id(x => x.Id, x =>
            {
                x.Column("OrderDetailID");
            });
            Property(x => x.UnitPrice, x =>
            {
                x.Column("UnitPrice");
                x.Type(NHibernateUtil.Currency);
            });
            Property(x => x.Quantity, x =>
            {
                x.Column("Quantity");
                x.Type(NHibernateUtil.Int16);
            });

            ManyToOne(x => x.Order, x =>
            {
                x.Column("OrderID");
            });

            ManyToOne(x => x.Product, x =>
            {
                x.Column("ProductID");
            });

            Table("OrderDetails");
        }
    }
}
