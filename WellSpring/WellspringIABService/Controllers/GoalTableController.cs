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
    public class GoalTableController : TableController<GoalTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GoalTableContext context = new GoalTableContext();
            DomainManager = new EntityDomainManager<GoalTable>(context, Request);
        }

        // GET tables/GoalTable
        public IQueryable<GoalTable> GetAllGoalTable()
        {
            return Query(); 
        }

        // GET tables/GoalTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<GoalTable> GetGoalTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/GoalTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GoalTable> PatchGoalTable(string id, Delta<GoalTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/GoalTable
        public async Task<IHttpActionResult> PostGoalTable(GoalTable item)
        {
            GoalTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/GoalTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGoalTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
