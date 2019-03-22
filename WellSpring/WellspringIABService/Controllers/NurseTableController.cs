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
    public class NurseTableController : TableController<NurseTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            NurseTableContext context = new NurseTableContext();
            DomainManager = new EntityDomainManager<NurseTable>(context, Request);
        }

        // GET tables/NurseTable
        public IQueryable<NurseTable> GetAllNurseTable()
        {
            return Query(); 
        }

        // GET tables/NurseTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<NurseTable> GetNurseTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/NurseTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<NurseTable> PatchNurseTable(string id, Delta<NurseTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/NurseTable
        public async Task<IHttpActionResult> PostNurseTable(NurseTable item)
        {
            NurseTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/NurseTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNurseTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
