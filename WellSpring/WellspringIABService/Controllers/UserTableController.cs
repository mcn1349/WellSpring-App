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
    public class UserTableController : TableController<UserTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            UserTableContext context = new UserTableContext();
            DomainManager = new EntityDomainManager<UserTable>(context, Request);
        }

        // GET tables/UserTable
        public IQueryable<UserTable> GetAllUserTable()
        {
            return Query(); 
        }

        // GET tables/UserTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserTable> GetUserTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserTable> PatchUserTable(string id, Delta<UserTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserTable
        public async Task<IHttpActionResult> PostUserTable(UserTable item)
        {
            UserTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
