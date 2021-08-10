using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employer Id is required")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public List<Skill> Skills { get; set; }

        public AddJobViewModel(List<Employer> allEmployers, List<Skill> allSkills )
        {
            Skills = allSkills;
            Employers = new List<SelectListItem>();

            foreach (var employer in allEmployers)
            {
                Employers.Add(new SelectListItem {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }



            Employers = Employers;
        }
    }
}
