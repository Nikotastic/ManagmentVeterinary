using ManagmentVeterinary.Interfaces;
namespace ManagmentVeterinary.Models;
    public class Consultation : VeterinaryService, INotificable
    {
        public Consultation(DateTime date) : base("General Consultation", date) { }

        public override void Attend(Pet pet)
        {
            Console.WriteLine($"Consulting pet {pet.Name} on {Date.ToShortDateString()} for {pet.Symptom}");
        }
        public void SendNotification(Pet pet)
        {
            Console.WriteLine($"Sending notification to {pet.Owner.Name} about {pet.Name} on {Date.ToShortDateString()}");
        }
        public void Cancel(Pet pet)
        {
            Console.WriteLine($"Canceling consultation for {pet.Name} on {Date.ToShortDateString()}");
        }

    }

