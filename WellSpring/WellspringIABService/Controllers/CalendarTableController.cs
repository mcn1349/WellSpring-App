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
    public class CalendarTableController : TableController<CalendarTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CalendarTableContext context = new CalendarTableContext();
            DomainManager = new EntityDomainManager<CalendarTable>(context, Request);
        }

        // GET tables/CalendarTable
        public IQueryable<CalendarTable> GetAllCalendarTable()
        {
            return Query(); 
        }

        // GET tables/CalendarTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CalendarTable> GetCalendarTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CalendarTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CalendarTable> PatchCalendarTable(string id, Delta<CalendarTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CalendarTable
        public async Task<IHttpActionResult> PostCalendarTable(CalendarTable item)
        {
            CalendarTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CalendarTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCalendarTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
