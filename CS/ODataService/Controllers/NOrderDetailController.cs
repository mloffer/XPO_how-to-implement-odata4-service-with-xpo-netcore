using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ODataService.NHibernate;
using System.Linq;

namespace ODataService.Controllers
{
    public class NOrderDetailController : Controller
    {
        private readonly ISession NSession;

        public NOrderDetailController(ISession nSession)
        {
            this.NSession = nSession;
        }


        [EnableQuery]
        public IQueryable<NOrderDetail> Get()
        {
            return NSession.Query<NOrderDetail>();
        }
    }
}
