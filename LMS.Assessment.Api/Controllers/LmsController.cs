using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;
using LMS.Assessment.Api.Entities;
using LMS.Assessment.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Assessment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LmsController : ControllerBase
{
    public LmsRepository lmsRepository;

    public LmsController(LawFirm[] seedLawFirmData = null)
    {
        lmsRepository = new LmsRepository();

        LawFirm[] lawFirms;
        Lender[] lenders;

        if (seedLawFirmData == null)
        {
            lawFirms = CreateFakeLawfirms();
        }
        else
        {
            lawFirms = seedLawFirmData;
        }

        lawFirms = CreateFakeLawfirms();
        lenders = CreateFakeLenders();

        for (int i = 0; i < lawFirms.Length; i++)
        {
            lmsRepository.CreateLawFirm(lawFirms[i]);
            lmsRepository.CreateLender(lenders[i]);
        }
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] string type = "lawFirm")
    {
        switch (type)
        {
            case "lawFirm":
                var lawFirms = lmsRepository.GetAllLawFirms();
                return Ok(lawFirms);

            case "lender":
                var result = lmsRepository.GetAllLenders();
                return Ok(result);
            
            default:
                return Ok();
        }
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] int id, string type = "lawFirm")
    {
        switch (type)
        {
            case "lawFirm":
                return Ok(lmsRepository.GetLawFirmById(id));

            case "lender":
                return Ok(lmsRepository.GetLenderById(id));
            
            default:
                return Ok();
        }
    }

    [HttpPut("Create")]
    public async Task<IActionResult> Create(CreateDto item)
    {
        switch (item.Type)
        {
            case "lawFirm":

                if (item.Id != 0)
                {
                    var newItem = new LawFirm();

                    newItem.Id = item.Id;
                    newItem.Address = item.Address;
                    newItem.Email = item.Email;
                    newItem.PhoneNumber = item.PhoneNumber;
                    newItem.Name = item.Name;
                    newItem.CreatedAt = item.CreatedAt;
                    newItem.CreatedBy = item.CreatedBy;

                    lmsRepository._lawFirmStore[item.Id] = newItem;
                    return Ok(item);
                }
                else
                {
                    var nextId = lmsRepository.GetAllLawFirms().Count;

                    var newItem = new LawFirm();

                    newItem.Id = nextId;
                    newItem.Address = item.Address;
                    newItem.Email = item.Email;
                    newItem.PhoneNumber = item.PhoneNumber;
                    newItem.Name = item.Name;
                    newItem.CreatedAt = item.CreatedAt;
                    newItem.CreatedBy = item.CreatedBy;

                    lmsRepository._lawFirmStore[item.Id] = newItem;
                    return Ok(item);
                }

            case "lender":
                if (item.Id != 0)
                {
                    var newItem = new Lender();

                    newItem.Id = item.Id;
                    newItem.Address = item.Address;
                    newItem.Email = item.Email;
                    newItem.PhoneNumber = item.PhoneNumber;
                    newItem.Name = item.Name;
                    newItem.CreatedAt = item.CreatedAt;
                    newItem.CreatedBy = item.CreatedBy;

                    lmsRepository._lenderStore[item.Id] = newItem;
                    return Ok(item);
                }
                else
                {
                    var nextId = lmsRepository.GetAllLenders().Count;

                    var newItem = new Lender();

                    newItem.Id = nextId;
                    newItem.Address = item.Address;
                    newItem.Email = item.Email;
                    newItem.PhoneNumber = item.PhoneNumber;
                    newItem.Name = item.Name;
                    newItem.CreatedAt = item.CreatedAt;
                    newItem.CreatedBy = item.CreatedBy;

                    lmsRepository._lenderStore.TryAdd(item.Id, newItem);
                    return Ok(item);
                }
            
            default:
                return Ok();
        }
    }
    
    public LawFirm[] CreateFakeLawfirms()
    {
        var fakeLawFirms = new LawFirm[]
        {
            new()
            {
                Id = 1,
                Name = "Harrington & Blythe Solicitors",
                Address = "12 Chancery Lane, London, WC2A 1PL, UK",
                PhoneNumber = "+44 20 7946 0101",
                Email = "contact@harringtonblythe.co.uk",
                CreatedBy = 1,
                CreatedAt = new DateTime(2026, 04, 28, 09, 15, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 2,
                Name = "Stonebridge Legal LLP",
                Address = "77 Deansgate, Manchester, M3 2BW, UK",
                PhoneNumber = "+44 161 496 0202",
                Email = "enquiries@stonebridgelegal.co.uk",
                CreatedBy = 1,
                CreatedAt = new DateTime(2026, 04, 30, 11, 05, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 3,
                Name = "Redwood & Co. Law",
                Address = "3 The Calls, Leeds, LS2 7JU, UK",
                PhoneNumber = "+44 113 496 0303",
                Email = "hello@redwoodlaw.co.uk",
                CreatedBy = 1,
                CreatedAt = new DateTime(2026, 05, 02, 14, 40, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 4,
                Name = "Kingswell Partners Solicitors",
                Address = "24 Park Row, Nottingham, NG1 6GR, UK",
                PhoneNumber = "+44 115 496 0404",
                Email = "office@kingswellpartners.co.uk",
                CreatedBy = 1,
                CreatedAt = new DateTime(2026, 05, 06, 08, 25, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 5,
                Name = "Northgate Conveyancing Ltd",
                Address = "18 The Headrow, Leeds, LS1 8TL, UK",
                PhoneNumber = "+44 113 496 0505",
                Email = "support@northgateconveyancing.co.uk",
                CreatedBy = 1,
                CreatedAt = new DateTime(2026, 05, 10, 16, 10, 00, DateTimeKind.Utc),
            },
        };

        return fakeLawFirms;
    }

    public Lender[] CreateFakeLenders()
    {
        var fakeLenders = new Lender[]
        {
            new()
            {
                Id = 1,
                Name = "Oakline Mortgage Finance",
                Address = "1 Broadgate, London, EC2M 2QS, UK",
                PhoneNumber = "+44 20 7946 1101",
                Email = "support@oaklinemortgage.co.uk",
                CreatedBy = 2,
                CreatedAt = new DateTime(2026, 04, 25, 10, 00, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 2,
                Name = "Cedar & Crest Lending",
                Address = "5 Colmore Row, Birmingham, B3 2BJ, UK",
                PhoneNumber = "+44 121 496 1202",
                Email = "hello@cedarcrestlending.co.uk",
                CreatedBy = 2,
                CreatedAt = new DateTime(2026, 04, 27, 13, 30, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 3,
                Name = "Harbourview Home Loans",
                Address = "8 Princes Dock, Liverpool, L3 1DL, UK",
                PhoneNumber = "+44 151 496 1303",
                Email = "contact@harbourviewloans.co.uk",
                CreatedBy = 2,
                CreatedAt = new DateTime(2026, 05, 01, 09, 45, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 4,
                Name = "Silverfern Bank Mortgages",
                Address = "10 Queen Street, Edinburgh, EH2 1JE, UK",
                PhoneNumber = "+44 131 496 1404",
                Email = "mortgages@silverfernbank.co.uk",
                CreatedBy = 2,
                CreatedAt = new DateTime(2026, 05, 05, 12, 20, 00, DateTimeKind.Utc),
            },
            new()
            {
                Id = 5,
                Name = "Bluepeak Building Society",
                Address = "2 Cathedral Quarter, Cardiff, CF10 3AF, UK",
                PhoneNumber = "+44 29 2096 1505",
                Email = "info@bluepeakbs.co.uk",
                CreatedBy = 2,
                CreatedAt = new DateTime(2026, 05, 12, 15, 05, 00, DateTimeKind.Utc),
            },
        };

        return fakeLenders;
    }

    // public static LawFirm[] GenerateFakeLawFirms()
    // {
    //     var lawFirmFaker = new Faker<LawFirm>("en_GB")
    //         .CustomInstantiator(f => new LawFirm()
    //         {
    //             CreatedAt = f.Date.Past(1)
    //         });

    //     return [.. lawFirmFaker.Generate(50)];
    // }
}
