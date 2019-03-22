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
    public class CommunityPostTableController : TableController<CommunityPostTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CommunityPostTableContext context = new CommunityPostTableContext();
            DomainManager = new EntityDomainManager<CommunityPostTable>(context, Request);
        }

        // GET tables/CommunityPostTable
        public IQueryable<CommunityPostTable> GetAllCommunityPostTable()
        {
            return Query(); 
        }

        // GET tables/CommunityPostTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CommunityPostTable> GetCommunityPostTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CommunityPostTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CommunityPostTable> PatchCommunityPostTable(string id, Delta<CommunityPostTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CommunityPostTable
        public async Task<IHttpActionResult> PostCommunityPostTable(CommunityPostTable item)
        {
            CommunityPostTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CommunityPostTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCommunityPostTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
