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
    public class CommentTableController : TableController<CommentTable>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CommentTableContext context = new CommentTableContext();
            DomainManager = new EntityDomainManager<CommentTable>(context, Request);
        }

        // GET tables/CommentTable
        public IQueryable<CommentTable> GetAllCommentTable()
        {
            return Query(); 
        }

        // GET tables/CommentTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CommentTable> GetCommentTable(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CommentTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CommentTable> PatchCommentTable(string id, Delta<CommentTable> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CommentTable
        public async Task<IHttpActionResult> PostCommentTable(CommentTable item)
        {
            CommentTable current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CommentTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCommentTable(string id)
        {
             return DeleteAsync(id);
        }
    }
}
