using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class LocalData
  {
    private static readonly string json = @"[
  {
    ""id"": ""5fb9953bd98214b6df37174d"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 88,
    ""durationInDays"": 35,
    ""bugsCount"": 74,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b9937c7bcd60c4bc5"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 68,
    ""durationInDays"": 55,
    ""bugsCount"": 52,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b899dd436c5604120"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 90,
    ""durationInDays"": 36,
    ""bugsCount"": 34,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b97e765bfc40b0e64"",
    ""userId"":1,
    ""name"": ""Frontend Project"",
    ""score"": 99,
    ""durationInDays"": 51,
    ""bugsCount"": 32,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b9cbcef501edc3282"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 97,
    ""durationInDays"": 68,
    ""bugsCount"": 42,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b85de8839957a723b"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 97,
    ""durationInDays"": 66,
    ""bugsCount"": 64,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953be21cbfc5e2384c0a"",
    ""userId"":1,
    ""name"": ""Fullstack Project"",
    ""score"": 79,
    ""durationInDays"": 61,
    ""bugsCount"": 63,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953bee0839034e07a1e9"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 66,
    ""durationInDays"": 62,
    ""bugsCount"": 50,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b7de958c3143892e8"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 95,
    ""durationInDays"": 59,
    ""bugsCount"": 65,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b474255e654c12d01"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 79,
    ""durationInDays"": 44,
    ""bugsCount"": 72,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953be4392e46fe106df2"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 93,
    ""durationInDays"": 66,
    ""bugsCount"": 72,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b532d8c6fbb42889c"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 100,
    ""durationInDays"": 39,
    ""bugsCount"": 47,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b173fda06ff170d73"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 87,
    ""durationInDays"": 68,
    ""bugsCount"": 56,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953bd75d55e63433cc43"",
    ""userId"":1,
    ""name"": ""Fullstack Project"",
    ""score"": 76,
    ""durationInDays"": 36,
    ""bugsCount"": 73,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953bc9bba25271a8044f"",
    ""userId"":1,
    ""name"": ""Frontend Project"",
    ""score"": 91,
    ""durationInDays"": 37,
    ""bugsCount"": 38,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953be15e723483509f48"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 84,
    ""durationInDays"": 37,
    ""bugsCount"": 57,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b86effeab4fadae71"",
    ""userId"":1,
    ""name"": ""Fullstack Project"",
    ""score"": 71,
    ""durationInDays"": 66,
    ""bugsCount"": 33,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b134a2003f8af1fd1"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 82,
    ""durationInDays"": 38,
    ""bugsCount"": 47,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b7f8236b00b4af7d2"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 98,
    ""durationInDays"": 38,
    ""bugsCount"": 75,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953bb533633938e96aea"",
    ""userId"":1,
    ""name"": ""Frontend Project"",
    ""score"": 90,
    ""durationInDays"": 60,
    ""bugsCount"": 40,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b729e99d31e89abe1"",
    ""userId"":1,
    ""name"": ""Fullstack Project"",
    ""score"": 77,
    ""durationInDays"": 67,
    ""bugsCount"": 74,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953b59b3068480a70fa9"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 99,
    ""durationInDays"": 37,
    ""bugsCount"": 65,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953bd1e1af04d1f33851"",
    ""userId"":1,
    ""name"": ""Fullstack Project"",
    ""score"": 73,
    ""durationInDays"": 58,
    ""bugsCount"": 62,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b9ea8b81780d1f3a8"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 88,
    ""durationInDays"": 72,
    ""bugsCount"": 52,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b116fcfab7b78d350"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 87,
    ""durationInDays"": 41,
    ""bugsCount"": 64,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b760c9a63057d2aa2"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 65,
    ""durationInDays"": 60,
    ""bugsCount"": 59,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953bdd09075f059e527c"",
    ""userId"":1,
    ""name"": ""Backend Project"",
    ""score"": 91,
    ""durationInDays"": 53,
    ""bugsCount"": 50,
    ""madeDadeline"": false
  },
  {
    ""id"": ""5fb9953b9123837114b6e5d7"",
    ""userId"":1,
    ""name"": ""Fullstack Project"",
    ""score"": 94,
    ""durationInDays"": 65,
    ""bugsCount"": 75,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953ba9d2809ab8b0309a"",
    ""userId"":1,
    ""name"": ""Frontend Project"",
    ""score"": 75,
    ""durationInDays"": 38,
    ""bugsCount"": 43,
    ""madeDadeline"": true
  },
  {
    ""id"": ""5fb9953bc5829fab66d03568"",
    ""userId"":1,
    ""name"": ""Design Project"",
    ""score"": 89,
    ""durationInDays"": 53,
    ""bugsCount"": 57,
    ""madeDadeline"": false
  }
]";
    public List<Projects> LoadProjects()
    {
      List<Projects> result = new List<Projects>();
      try
      {
        result = JsonConvert.DeserializeObject<List<Projects>>(json);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return result;
    }
  }
}
