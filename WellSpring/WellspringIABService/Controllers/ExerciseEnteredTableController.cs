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
    public class ExerciseEnteredTableController : TableController<ExerciseEnteredTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ExerciseEnteredTableContext context = new ExerciseEnteredTableContext();
            DomainManager = new EntityDomainManager<ExerciseEnteredTable>(context, Request);
        }

        // GET tables/ExerciseEnteredTable
        public IQueryable<ExerciseEnteredTable> GetAllExerciseEnteredTable()
        {
            return Query(); 
        }

        // GET tables/ExerciseEnteredTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ExerciseEnteredTable> GetExerciseEnteredTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ExerciseEnteredTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ExerciseEnteredTable> PatchExerciseEnteredTable(string id, Delta<ExerciseEnteredTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ExerciseEnteredTable
        public async Task<IHttpActionResult> PostExerciseEnteredTable(ExerciseEnteredTable item)
        {
            ExerciseEnteredTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ExerciseEnteredTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteExerciseEnteredTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
