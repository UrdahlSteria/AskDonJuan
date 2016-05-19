using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AskDonJuan.Models
{
    public class QueryModel
    {
        [Key]
        public int QueryKey { get; set; }

        //Should InRelationship be unknown as well?
        [Display(Name = "Are you in a relationship?")]
        public bool InRelationship { get; set; }

        [Display(Name = "My Age")]
        [Range(16, 99)]
        [Required(ErrorMessage = "Please enter your age.")]
        public int UserAge { get; set; }

        [Display(Name = "Partner Age")]
        [Range(16,99)]
        public int OtherAge { get; set; }

        [Display(Name = "Relationship Length Type")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DurationEnum DurationType{ get; set; }

        [Display(Name = "Relationship Length" )]
        public int DurationVariable { get; set; }


        public enum DurationEnum
        {
            Number_of_Dates,
            Weeks_Dating,
            Weeks_Together,
            Years_Together
        };

        //[Required]
        //[RegularExpression(".+\\@.+\\..+")]
        //public string Email { get; set; }


        [Display(Name = "How mean are you?")]
        [Required(ErrorMessage = "Please enter how kind/mean you want to be")]
        public MeanessEnum Meaness { get; set; }
        public enum MeanessEnum
        {
            Kind,
            Normal,
            Mean
        };

    }
}
