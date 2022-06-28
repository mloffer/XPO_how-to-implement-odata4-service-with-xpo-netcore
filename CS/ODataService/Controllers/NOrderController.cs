using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ODataService.NHibernate;
using System.Linq;

namespace ODataService.Controllers
{
    public class NOrderController : Controller
    {
        private readonly ISession NSession;

        public NOrderController(ISession nSession)
        {
            this.NSession = nSession;
        }


        [EnableQuery]
        public IQueryable<NOrder> Get()
        {
            return NSession.Query<NOrder>();
        }
    }
}
