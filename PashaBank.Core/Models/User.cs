using PashaBank.Core.Models.Enums;
using PashaBank.Core.Vallidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PashaBank.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "სახელი უნდა შეიცავდეს მაქსიმუმ 50 სიმბოლოს!")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "გვარი უნდა შეიცავდეს მაქსიმუმ 50 სიმბოლოს!")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public byte[] Picture { get; set; }
        [Required]
        public DocumentType DocumentType { get; set; }
        [StringLength(10, ErrorMessage = "საბუთის სერია უნდა შეიცავდეს მაქსიმუმ 10 სიმბოლოს!")]
        public string DocumentSeries { get; set; }
        [StringLength(10, ErrorMessage = "საბუთის ნომერი უნდა შეიცავდეს მაქსიმუმ 10 სიმბოლოს!")]
        public string DocumentNumber { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime DocumentTerm { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "პირადობის ნომერი უნდა შეიცავდეს მაქსიმუმ 50 სიმბოლოს!")]
        public string PersonalNumber { get; set; }
        [StringLength(100, ErrorMessage = "გამცემი ორგანო უნდა შეიცავდეს მაქსიმუმ 100 სიმბოლოს!")]

        public string IssuingBody { get; set; }
        [Required]
        public ContactType ContactType { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "საკონტაქტო ინფორმაცია უნდა შეიცავდეს მაქსიმუმ 100 სიმბოლოს!")]

        public string ContactInformation { get; set; }
        [Required]
        public AddressType AddressType { get; set; }
        [StringLength(100, ErrorMessage = "მისამართი უნდა შეიცავდეს მაქსიმუმ 100 სიმბოლოს!")]
        [Required]
        public string Address { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? RecommenderId { get; set; }
        [ForeignKey("RecommenderId")]
        public User Recommender { get; set; }
        public string Role { get; set; } = UserRoles.Distributtor.ToString();
        public ICollection<User> RecommendedUsers { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Bonus> Bonuses { get; set; }
        [ValidateRecommendationsCount(ErrorMessage = "Maximum of 3 recommendations allowed.")]
        public ICollection<Recommendation> Recommendations { get; set; }
    }
}
