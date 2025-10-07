using ManagmentVeterinary.Models;
namespace ManagmentVeterinary.Interfaces;

public interface INotificable
{
    void SendNotification(Pet pet);
}