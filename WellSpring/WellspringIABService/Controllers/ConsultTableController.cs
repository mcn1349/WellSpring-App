using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using WellspringIABService.DataObjects;
using WellspringIABService.Models;

namespace WellspringIABService.Controllers
{
    public class ConsultTableController : TableController<ConsultTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ConsultTableContext context = new ConsultTableContext();
            DomainManager = new EntityDomainManager<ConsultTable>(context, Request);
        }

        // GET tables/ConsultTable
        public IQueryable<ConsultTable> GetAllConsultTable()
        {
            return Query(); 
        }

        // GET tables/ConsultTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ConsultTable> GetConsultTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ConsultTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ConsultTable> PatchConsultTable(string id, Delta<ConsultTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ConsultTable
        public async Task<IHttpActionResult> PostConsultTable(ConsultTable item)
        {
            ConsultTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ConsultTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteConsultTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
