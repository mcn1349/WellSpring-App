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
    public class MeetUpMemberTableController : TableController<MeetUpMemberTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MeetUpMemberTableContext context = new MeetUpMemberTableContext();
            DomainManager = new EntityDomainManager<MeetUpMemberTable>(context, Request);
        }

        // GET tables/MeetUpMemberTable
        public IQueryable<MeetUpMemberTable> GetAllMeetUpMemberTable()
        {
            return Query(); 
        }

        // GET tables/MeetUpMemberTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MeetUpMemberTable> GetMeetUpMemberTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/MeetUpMemberTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MeetUpMemberTable> PatchMeetUpMemberTable(string id, Delta<MeetUpMemberTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/MeetUpMemberTable
        public async Task<IHttpActionResult> PostMeetUpMemberTable(MeetUpMemberTable item)
        {
            MeetUpMemberTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/MeetUpMemberTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMeetUpMemberTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
