using ManagmentVeterinary.Models;
namespace ManagmentVeterinary.Interfaces;

// Interface for notification
public interface INotification
{
    void SendNotification(string message);
}