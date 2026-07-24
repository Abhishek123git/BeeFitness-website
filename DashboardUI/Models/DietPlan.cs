namespace DashboardUI.Models
{
    // Represents a single diet plan card's data
    public class DietPlan
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CardTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Reads { get; set; }
        public int Comments { get; set; }
        public string DetailUrl { get; set; } = string.Empty;


        // Convenience property to format "782K Reads" style text
        public string FormattedReads =>
            Reads >= 1000 ? $"{Reads / 1000.0:0.#}K Reads" : $"{Reads} Reads";

        public string FormattedComments =>
            $"{Comments} Comment{(Comments == 1 ? "" : "s")}";
    }    
}
