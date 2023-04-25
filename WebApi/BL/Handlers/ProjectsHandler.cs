using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Handlers
{
  public class ProjectsHandler
  {
    public void LoadLocalData()
    {
      try
      {
        List<Projects> localProjects = new LocalData().LoadProjects();

        using (var db = new TestEntities())
        {

          foreach (var project in localProjects)
          {
            var dbProject = db.Projects.FirstOrDefault(p => p.id == project.id);
            if (dbProject == null)
            {
              db.Projects.Add(project);
            }
          }
          db.SaveChanges();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<Project> GetProjects(int userId)
    {
      List<Project> res = new List<Project>();
      try
      {
        using (var db = new TestEntities())
        {
          var projects = db.Projects.Where(p=>p.userId == userId).ToList();
          foreach (var project in projects)
          {
            res.Add(new Project()
            {
              id = project.id,
              name = project.name,
              bugsCount = project.bugsCount != null ? (int)project.bugsCount : 0,
              durationInDays = project.durationInDays != null ? (int)project.durationInDays : 0,
              madeDadeline = project.madeDadeline != null ? (bool)project.madeDadeline : false,
              score = project.score != null ? (int)project.score : 0,
            });
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return res;
    }
  }
}
