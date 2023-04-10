using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        return View();
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
    public IActionResult Results(string searchType,string searchTerm)
    { 
        List<Job> jobs;
        {
            if (searchTerm.ToLower().Equals("all"))
            {
                jobs = JobData.FindAll();
            } else if (searchTerm.ToLower().Equals(""))
                {
                jobs = JobData.FindAll();
            } else
            {
                JobData.FindByColumnAndValue(searchType,searchTerm);
                jobs = JobData.FindByColumnAndValue();
            }
        }
        return View(Results);
    }
    
}

