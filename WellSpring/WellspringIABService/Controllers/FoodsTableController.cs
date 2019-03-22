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
    public class FoodsTableController : TableController<FoodsTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            FoodsTableContext context = new FoodsTableContext();
            DomainManager = new EntityDomainManager<FoodsTable>(context, Request);
        }

        // GET tables/FoodsTable
        public IQueryable<FoodsTable> GetAllFoodsTable()
        {
            return Query(); 
        }

        // GET tables/FoodsTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<FoodsTable> GetFoodsTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/FoodsTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<FoodsTable> PatchFoodsTable(string id, Delta<FoodsTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/FoodsTable
        public async Task<IHttpActionResult> PostFoodsTable(FoodsTable item)
        {
            FoodsTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/FoodsTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFoodsTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
