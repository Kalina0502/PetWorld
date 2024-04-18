﻿using PetWorld.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Core.Models.Adoption
{
    public class AllAdoptionsQueryModel
    {
        public int AdoptionPetsPerPage { get; } = 3;

        public string Species { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public AdoptionSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public int TotalAdoptionPetsCount { get; set; }

        [Display(Name = "Speciest List")]
        public IEnumerable<string> SpeciesList { get; set; } = null!;

        public IEnumerable<AdoptionServiceModel> Adoptions { get; set; } = new List<AdoptionServiceModel>();
    }
}
