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
    public class FoodEnteredTableController : TableController<FoodEnteredTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            FoodEnteredTableContext context = new FoodEnteredTableContext();
            DomainManager = new EntityDomainManager<FoodEnteredTable>(context, Request);
        }

        // GET tables/FoodEnteredTable
        public IQueryable<FoodEnteredTable> GetAllFoodEnteredTable()
        {
            return Query(); 
        }

        // GET tables/FoodEnteredTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<FoodEnteredTable> GetFoodEnteredTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/FoodEnteredTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<FoodEnteredTable> PatchFoodEnteredTable(string id, Delta<FoodEnteredTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/FoodEnteredTable
        public async Task<IHttpActionResult> PostFoodEnteredTable(FoodEnteredTable item)
        {
            FoodEnteredTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/FoodEnteredTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFoodEnteredTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
