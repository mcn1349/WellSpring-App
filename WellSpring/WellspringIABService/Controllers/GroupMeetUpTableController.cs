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
    public class GroupMeetUpTableController : TableController<GroupMeetUpTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GroupMeetUpTableContext context = new GroupMeetUpTableContext();
            DomainManager = new EntityDomainManager<GroupMeetUpTable>(context, Request);
        }

        // GET tables/GroupMeetUpTable
        public IQueryable<GroupMeetUpTable> GetAllGroupMeetUpTable()
        {
            return Query(); 
        }

        // GET tables/GroupMeetUpTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<GroupMeetUpTable> GetGroupMeetUpTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/GroupMeetUpTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GroupMeetUpTable> PatchGroupMeetUpTable(string id, Delta<GroupMeetUpTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/GroupMeetUpTable
        public async Task<IHttpActionResult> PostGroupMeetUpTable(GroupMeetUpTable item)
        {
            GroupMeetUpTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/GroupMeetUpTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGroupMeetUpTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
