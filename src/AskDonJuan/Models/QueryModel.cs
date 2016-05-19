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
        [DefaultValue(false)]
        public bool InRelationship { get; set; }

        [Display(Name = "My Age")]
        [Range(14, 99)]
        [DefaultValue(25)]
        [Required(ErrorMessage = "Please enter your age.")]
        public int UserAge { get; set; }

        [Display(Name = "Partner Age")]
        [Range(14, 99)]
        [DefaultValue(25)]
        public int OtherAge { get; set; }

        [Required(ErrorMessage = "Please enter type of relationship.")]
        [Display(Name = "Relationship Length Type")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DurationEnum DurationType{ get; set; }

        [Display(Name = "Relationship Length" )]
        [DefaultValue(1)]
        public int DurationVariable { get; set; }


        public enum DurationEnum
        {
            [Display( Name ="Number of Dates: ")]
            Number_of_Dates,
            [Display(Name = "Weeks Dating: ")]
            Weeks_Dating,
            [Display(Name = "Weeks Together: ")]
            Weeks_Together,
            [Display(Name = "Years Together: ")]
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
