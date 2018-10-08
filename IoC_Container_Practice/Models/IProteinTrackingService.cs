namespace IoC_Container_Practice.Models
{
    public interface IProteinTrackingService
    {
        int Goal { get; set; }
        int Total { get; set; }

        void AddProtein(int amount);
    }
}