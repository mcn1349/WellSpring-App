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
    public class ExerciseTableController : TableController<ExerciseTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ExerciseTableContext context = new ExerciseTableContext();
            DomainManager = new EntityDomainManager<ExerciseTable>(context, Request);
        }

        // GET tables/ExerciseTable
        public IQueryable<ExerciseTable> GetAllExerciseTable()
        {
            return Query(); 
        }

        // GET tables/ExerciseTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ExerciseTable> GetExerciseTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ExerciseTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ExerciseTable> PatchExerciseTable(string id, Delta<ExerciseTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ExerciseTable
        public async Task<IHttpActionResult> PostExerciseTable(ExerciseTable item)
        {
            ExerciseTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ExerciseTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteExerciseTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
