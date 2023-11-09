namespace BtkAkademi.Models
{
    public class Candidate//Adaylar sınıfı
    {
        //Id yerine adayın unique Email olacağını düşünüyorum.
        public string? Email { get; set; }=String.Empty;
        public string? FirstName { get; set; }=String.Empty;
        public string? LastName { get; set; }=String.Empty;
        public string? FullName =>$"{FirstName} {LastName?.ToUpper()}";
        public int? Age { get; set; }
        public string? SelectedCourse { get; set; }=String.Empty;
        public DateTime? ApplyAt { get; set; }
        
        public Candidate()
        {
            ApplyAt=DateTime.Now;
        }

    }
}