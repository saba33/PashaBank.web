using PashaBank.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PashaBank.Services.Models.RequestModels.User
{
    public class EditUserRequest
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be no more than 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name must be no more than 50 characters.")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Document type is required.")]
        public DocumentType DocumentType { get; set; }

        [StringLength(10, ErrorMessage = "Document series must be no more than 10 characters.")]
        public string DocumentSeries { get; set; }

        [StringLength(10, ErrorMessage = "Document number must be no more than 10 characters.")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "Issue date is required.")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Document term is required.")]
        public DateTime DocumentTerm { get; set; }

        [Required(ErrorMessage = "Personal number is required.")]
        [StringLength(50, ErrorMessage = "Personal number must be no more than 50 characters.")]
        public string PersonalNumber { get; set; }

        [StringLength(100, ErrorMessage = "Issuing body must be no more than 100 characters.")]
        public string IssuingBody { get; set; }

        [Required(ErrorMessage = "Contact type is required.")]
        public ContactType ContactType { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        [StringLength(100, ErrorMessage = "Contact information must be no more than 100 characters.")]
        public string ContactInformation { get; set; }

        [Required(ErrorMessage = "Address type is required.")]
        public AddressType AddressType { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address must be no more than 100 characters.")]
        public string Address { get; set; }
    }

}
