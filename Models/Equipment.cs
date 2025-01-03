namespace AssignmentApi.Models
{
    public class Equipment
    {
        public int CustomerId { get; set; }
        public List<string> EquipmentList { get; set; } = new List<string>(); // Initialized with an empty list
    }
}
