using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Assessment.Api.Abstractions;

namespace LMS.Assessment.Api.Entities;

public class LawFirm : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Lender : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}