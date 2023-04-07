using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{

    [Route("api/[Controller]/[action]")]
    public class ProjectTableController : Controller

    {
        private readonly DataContext _dbContext;
        public ProjectTableController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<ProjectTable> GetAll()
        {
            return _dbContext.ProjectTables.ToList();
        }
        [HttpGet("{Id:int}")]
        public ActionResult<ProjectTable> GetById(int Id) 
        {
            return _dbContext.ProjectTables.Find(Id);
        }
        [HttpPost]
        public async Task<IActionResult> Createtable([FromBody] ProjectTable createproject)
        {


            await _dbContext.ProjectTables.AddAsync(createproject);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            { Message = "Added to the table" });

        }
        [HttpPut]
        public ProjectTable Updatedetails([FromBody] ProjectTable details)
        {
            _dbContext.ProjectTables.Update(details);
            _dbContext.SaveChanges();
            return details;
        }
        [HttpDelete]
        public ActionResult <ProjectTable> DeleteById(int Id)
        {
            var deleteproject = _dbContext.ProjectTables.Find(Id);
            //var oldStudent = this.students.Find(s => s.Id == Id);
            _dbContext.ProjectTables.Remove(deleteproject);
            _dbContext.SaveChanges();
            return deleteproject;
        }
    }
}
