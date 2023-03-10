using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Rudrani_Tech_CRM.DTOs;
using Rudrani_Tech_CRM.Models;

namespace Rudrani_Tech_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCreateLeadsController : ControllerBase
    {
        private readonly RudraniCrmContext _context;
        private SqlConnection con;

        public TblCreateLeadsController(RudraniCrmContext context)
        {
            _context = context;
        }

        // GET: api/TblCreateLeads
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblCreateLead>>> GetTblCreateLeads()
        //{
        //  if (_context.TblCreateLeads == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.TblCreateLeads.ToListAsync();
        //}

        // GET: api/TblCreateLeads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCreateLead>> GetTblCreateLead([FromRoute]int id)
        {
          if (_context.TblCreateLeads == null)
          {
              return NotFound();
          }
            var tblCreateLead = await _context.TblCreateLeads.FindAsync(id);

            if (tblCreateLead == null)
            {
                return NotFound();
            }
            
            //This code will helps to convert byte[] to image
            byte[] img = tblCreateLead.LeadImage;
            MemoryStream ms = new MemoryStream(img);
            Image i = Image.FromStream(ms);           
            //tblCreateLead.Profile = i;

            //i.Save(@"c:\s\pic.png", System.Drawing.Imaging.ImageFormat.Png);

            //Convert byte arry to base64string
            string imreBase64Data = Convert.ToBase64String(img);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            tblCreateLead.ImgURL = imgDataURL;

            //For hiding byte[]

            //if (tblCreateLead.LeadImage != null)
            //{
            //    return Ok(File(tblCreateLead.LeadImage, "image/jpg"));
            //}

            //test to display image
            //var imge = tblCreateLead.LeadImage;
            //byte[] pic = Convert.FromBase64String(imreBase64Data);

            //return Ok(File(pic,"auto"));
            return Ok(tblCreateLead);

        }

        // PUT: api/TblCreateLeads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCreateLead(int id, [FromForm]UpdateLeadDTO updateLeadDTO)
        {
            //if (id != updateLeadDTO.LeadID)
            //{
            //    return BadRequest("Id not matched");
            //}

            var updateLead = await _context.TblCreateLeads.FindAsync(id);

            if (updateLead == null)
            {
                return NotFound("Data not Found with given Id.");
            }
            updateLead.LeadOwner = updateLeadDTO.LeadOwner != null ? updateLeadDTO.LeadOwner : updateLead.LeadOwner;
            updateLead.Company = updateLeadDTO.Company != null ? updateLeadDTO.Company : updateLead.Company;
            updateLead.FirstNameTitle = updateLeadDTO.FirstNameTitle != null ? updateLeadDTO.FirstNameTitle : updateLead.FirstNameTitle;
            updateLead.FirstName = updateLeadDTO.FirstName != null ? updateLeadDTO.FirstName : updateLead.FirstName;
            updateLead.LastName = updateLeadDTO.LastName != null ? updateLeadDTO.LastName : updateLead.LastName;
            updateLead.Title = updateLeadDTO.Title != null ? updateLeadDTO.Title : updateLead.Title;
            updateLead.Email = updateLeadDTO.Email != null ? updateLeadDTO.Email : updateLead.Email;
            updateLead.Tel = updateLeadDTO.Tel != null ? updateLeadDTO.Tel : updateLead.Tel;
            updateLead.Fax = updateLeadDTO.Fax != null ? updateLeadDTO.Fax : updateLead.Fax;
            updateLead.Mobile = updateLeadDTO.Mobile != null ? updateLeadDTO.Mobile : updateLead.Mobile;
            updateLead.Website = updateLeadDTO.Website != null ? updateLeadDTO.Website : updateLead.Website;
            updateLead.LeadSource = updateLeadDTO.LeadSource != null ? updateLeadDTO.LeadSource : updateLead.LeadSource;
            updateLead.LeadStatus = updateLeadDTO.LeadStatus != null ? updateLeadDTO.LeadStatus : updateLead.LeadStatus;
            updateLead.Industry = updateLeadDTO.Industry != null ? updateLeadDTO.Industry : updateLead.Industry;
            updateLead.NoOfEmployees = updateLeadDTO.NoOfEmployees != null ? updateLeadDTO.NoOfEmployees : updateLead.NoOfEmployees;
            updateLead.AnnualRevenue = updateLeadDTO.AnnualRevenue != null ? updateLeadDTO.AnnualRevenue : updateLead.AnnualRevenue;
            updateLead.Rating = updateLeadDTO.Rating != null ? updateLeadDTO.Rating : updateLead.Rating;
            updateLead.EmailOptOut = updateLeadDTO.EmailOptOut != null ? updateLeadDTO.EmailOptOut : updateLead.EmailOptOut;
            updateLead.SkypeId = updateLeadDTO. SkypeId != null ? updateLeadDTO.SkypeId : updateLead.SkypeId;
            updateLead.SecondaryEmail = updateLeadDTO. SecondaryEmail != null ? updateLeadDTO.SecondaryEmail : updateLead.SecondaryEmail;
            updateLead.Twitter = updateLeadDTO.Twitter != null ? updateLeadDTO.Twitter : updateLead.Twitter;
            updateLead.Street = updateLeadDTO.Street != null ? updateLeadDTO.Street : updateLead.Street;
            updateLead.City = updateLeadDTO.City != null ? updateLeadDTO.City : updateLead.City;
            updateLead.State = updateLeadDTO.State != null ? updateLeadDTO.State : updateLead.State;
            updateLead.Zipcode = updateLeadDTO.Zipcode != null ? updateLeadDTO.Zipcode : updateLead.Zipcode;
            updateLead.Country = updateLeadDTO.Country != null ? updateLeadDTO.Country : updateLead.Country;
            updateLead.Description = updateLeadDTO.Description != null ? updateLeadDTO.Description : updateLead.Description;
            updateLead.Role = updateLeadDTO.Role != null ? updateLeadDTO.Role : updateLead.Role;

            if (updateLeadDTO.LeadImageJPG != null)
            {
                using (var target = new MemoryStream())
                {
                    updateLeadDTO.LeadImageJPG.CopyTo(target);
                    updateLead.LeadImage = target.ToArray();
                }
            }

            //_context.Entry(updateLeadDTO).State = EntityState.Modified;

            _context.TblCreateLeads.Update(updateLead);;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("changes saved");
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TblCreateLeadExists(id))
                //{
                //    return NotFound("no user found");
                //}
                //else
                //{
                throw;
                //}
            }

            //return NoContent();
        }

        // POST: api/TblCreateLeads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateLeadDTO>> PostTblCreateLead([FromForm]CreateLeadDTO tblCreateLead)
        {
          if (_context.TblCreateLeads == null)
          {
              return Problem("Entity set 'RudraniCrmContext.TblCreateLeads'  is null.");
          }
            var createLead = new TblCreateLead
            {
                Company = tblCreateLead.Company,
                LeadOwner = tblCreateLead.LeadOwner,
                FirstNameTitle = tblCreateLead.FirstNameTitle,
                FirstName = tblCreateLead.FirstName,
                LastName = tblCreateLead.LastName,
                Title = tblCreateLead.Title,
                Email = tblCreateLead.Email,
                Tel = tblCreateLead.Tel,
                Fax = tblCreateLead.Fax,
                Mobile = tblCreateLead.Mobile,
                Website = tblCreateLead.Website,
                LeadSource = tblCreateLead.LeadSource,
                LeadStatus=tblCreateLead.LeadStatus,
                Industry=tblCreateLead.Industry,
                NoOfEmployees=tblCreateLead.NoOfEmployees,
                AnnualRevenue= tblCreateLead.AnnualRevenue,
                Rating=tblCreateLead.Rating,
                EmailOptOut=tblCreateLead.EmailOptOut,
                SkypeId=tblCreateLead.SkypeId,
                SecondaryEmail=tblCreateLead.SecondaryEmail,
                Twitter=tblCreateLead.Twitter,
                Street=tblCreateLead.Street,
                City=tblCreateLead.City,
                State=tblCreateLead.State,
                Zipcode=tblCreateLead.Zipcode,
                Country=tblCreateLead.Country,
                Description=tblCreateLead.Description,
                Role=tblCreateLead.Role,
            };
            if (tblCreateLead.LeadImageJPG != null)
            {
                ////Getting FileName
                //var fileName = Path.GetFileName(tblCreateLead.LeadImageJPG.FileName);
                ////Getting file Extension
                //var fileExtension = Path.GetExtension(fileName);
                //// concatenating  FileName + FileExtension
                //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                using (var target = new MemoryStream())
                {
                    tblCreateLead.LeadImageJPG.CopyTo(target);
                    createLead.LeadImage = target.ToArray();
                }
            }
            _context.TblCreateLeads.Add(createLead);
            await _context.SaveChangesAsync();

            var id = createLead.LeadId;

            //return CreatedAtAction("GetTblCreateLead", new { id = createLead.LeadId }, createLead);
            return Ok("Lead created with ID: "+createLead.LeadId);
        }

        // DELETE: api/TblCreateLeads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCreateLead(int id)
        {
            if (_context.TblCreateLeads == null)
            {
                return NotFound();
            }
            var tblCreateLead = await _context.TblCreateLeads.FindAsync(id);
            if (tblCreateLead == null)
            {
                return NotFound();
            }

            _context.TblCreateLeads.Remove(tblCreateLead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCreateLeadExists(int id)
        {
            return (_context.TblCreateLeads?.Any(e => e.LeadId == id)).GetValueOrDefault();
        }
    }
}
