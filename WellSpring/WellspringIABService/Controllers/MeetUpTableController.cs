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
    public class MeetUpTableController : TableController<MeetUpTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MeetUpTableContext context = new MeetUpTableContext();
            DomainManager = new EntityDomainManager<MeetUpTable>(context, Request);
        }

        // GET tables/MeetUpTable
        public IQueryable<MeetUpTable> GetAllMeetUpTable()
        {
            return Query(); 
        }

        // GET tables/MeetUpTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MeetUpTable> GetMeetUpTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/MeetUpTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MeetUpTable> PatchMeetUpTable(string id, Delta<MeetUpTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/MeetUpTable
        public async Task<IHttpActionResult> PostMeetUpTable(MeetUpTable item)
        {
            MeetUpTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/MeetUpTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMeetUpTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
