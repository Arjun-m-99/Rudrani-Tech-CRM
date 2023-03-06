using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Rudrani_Tech_CRM.Models;

public partial class TblCreateLead
{
    public int LeadId { get; set; }

    public string LeadOwner { get; set; } = null!;

    public string Company { get; set; } = null!;

    public string FirstNameTitle { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Title { get; set; }

    public string Email { get; set; } = null!;

    public long? Tel { get; set; }

    public string? Fax { get; set; }

    public long Mobile { get; set; }

    public string? Website { get; set; }

    public string? LeadSource { get; set; }

    public string? LeadStatus { get; set; }

    public string? Industry { get; set; }

    public int? NoOfEmployees { get; set; }

    public long? AnnualRevenue { get; set; }

    public string? Rating { get; set; }

    public bool? EmailOptOut { get; set; }

    public string? SkypeId { get; set; }

    public string? SecondaryEmail { get; set; }

    public string? Twitter { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? Zipcode { get; set; }

    public string? Country { get; set; }

    public string? Description { get; set; }

    public string Role { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public byte[]? LeadImage { get; set; }

    [NotMapped] //Prevent fromundeclaration error from context
    public Image Profile { get; set; }
    
    [NotMapped] //Prevent fromundeclaration error from context
    public string ImgURL { get; set; }
}
