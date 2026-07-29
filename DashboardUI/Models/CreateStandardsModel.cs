using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace DashboardUI.Models
{    
    public class CreateStandardsModel
    {
        public string Exercise { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a gender")]
        public string Gender { get; set; } = "Male";

        [Required(ErrorMessage = "Age is required")]
        [Range(10, 100, ErrorMessage = "Age must be between 10 and 100")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Bodyweight is required")]
        [Range(20, 300, ErrorMessage = "Bodyweight must be between 20 and 300 kg")]
        public double? Bodyweight { get; set; }
    }
    public abstract class ExerciseComponentBase : ComponentBase
    {
        protected virtual string ExerciseDisplayName =>
            System.Text.RegularExpressions.Regex.Replace(GetType().Name, "(\\B[A-Z])", " $1");
    }
}
