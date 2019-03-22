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
    public class CustomFoodsTableController : TableController<CustomFoodsTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CustomFoodsTableContext context = new CustomFoodsTableContext();
            DomainManager = new EntityDomainManager<CustomFoodsTable>(context, Request);
        }

        // GET tables/CustomFoodsTable
        public IQueryable<CustomFoodsTable> GetAllCustomFoodsTable()
        {
            return Query(); 
        }

        // GET tables/CustomFoodsTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CustomFoodsTable> GetCustomFoodsTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CustomFoodsTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CustomFoodsTable> PatchCustomFoodsTable(string id, Delta<CustomFoodsTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CustomFoodsTable
        public async Task<IHttpActionResult> PostCustomFoodsTable(CustomFoodsTable item)
        {
            CustomFoodsTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CustomFoodsTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCustomFoodsTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
