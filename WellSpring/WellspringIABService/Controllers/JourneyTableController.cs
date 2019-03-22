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
    public class JourneyTableController : TableController<JourneyTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            JourneyTableContext context = new JourneyTableContext();
            DomainManager = new EntityDomainManager<JourneyTable>(context, Request);
        }

        // GET tables/JourneyTable
        public IQueryable<JourneyTable> GetAllJourneyTable()
        {
            return Query(); 
        }

        // GET tables/JourneyTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<JourneyTable> GetJourneyTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/JourneyTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<JourneyTable> PatchJourneyTable(string id, Delta<JourneyTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/JourneyTable
        public async Task<IHttpActionResult> PostJourneyTable(JourneyTable item)
        {
            JourneyTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/JourneyTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteJourneyTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
