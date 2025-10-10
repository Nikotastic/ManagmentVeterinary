using ManagmentVeterinary.Models;
namespace ManagmentVeterinary.Interfaces;

public interface INotification
{
    void SendNotification(string message);
}