using System.Runtime.CompilerServices;

namespace WebServiceApp.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseEntity
{
    [Column("createddate")]
    public DateTime? CreatedDate { get; set; }
    //[Column("createdby")]
    //public string CreatedBy { get; set; }
    [Column("updateddate")]
    public DateTime? UpdatedDate { get; set; } 
    //[Column("updatedby")]
    //public string UpdatedBy { get; set; }  
}