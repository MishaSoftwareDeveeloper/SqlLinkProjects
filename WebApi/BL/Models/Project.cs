using System;


namespace BL.Models
{
  public class Project
  {
    public string id { get; set; }
    public int userId { get; set; }
    public string name { get; set; }
    public int score { get; set; }
    public int durationInDays { get; set; }
    public int bugsCount { get; set; }
    public bool madeDadeline { get; set; }
  }
}
