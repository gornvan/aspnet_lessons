namespace lesson13_Security.Entities
{
    public class Tire : BaseEntity
    {
        public DateTime? ExpluatationStartDate { get; set; }

        public virtual Car? OnCar { get; set; }
    }
}