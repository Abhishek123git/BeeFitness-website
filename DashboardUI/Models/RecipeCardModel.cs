namespace DashboardUI.Models
{
    public class RecipeCardModel
    {
        public int Id { get; set; }
        public string CardTitle { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string DetailUrl { get; set; } = string.Empty;
    }
}
