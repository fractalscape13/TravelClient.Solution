using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace GitJobs.Models
{
  public class Job
  {
    public int JobId { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }

    public static List<Job> GetAll()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Job> jobList = JsonConvert.DeserializeObject<List<Job>>(jsonResponse.ToString());

      return jobList;
    }

    public static List<Job> Search(string description, string location, string title)
    {
      var apiCallTask = ApiHelper.Search(description, location, title);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Job> jobList = JsonConvert.DeserializeObject<List<Job>>(jsonResponse.ToString());

      return jobList;
    }

    public static Job GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse =JsonConvert.DeserializeObject<JObject>(result);
      Job job = JsonConvert.DeserializeObject<Job>(jsonResponse.ToString());

      return job;
    }

    // public static void Post(Job job)
    // {
    //   string jsonJob = JsonConvert.SerializeObject(job);
    //   var apiCallTask = ApiHelper.Post(jsonJob);
    // }

    // public static void Put(Job job)
    // {
    //   string jsonJob = JsonConvert.SerializeObject(job);
    //   var apiCallTask = ApiHelper.Put(job.JobId, jsonJob);
    // }

    // public static void Delete(int id)
    // {
    //   var apiCallTask = ApiHelper.Delete(id);
    // }
  }
}