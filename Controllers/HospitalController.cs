using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web.Http;


namespace WebApiOrionHospital.Controllers
{

    public class HospitalController : ApiController
    {
        
        [System.Web.Http.Authorize]
        public IHttpActionResult Get([FromQuery] string searchInput = "", int page = 1, int pageSize = 10)
        {
            using (HospitaldbEntities entities = new HospitaldbEntities())
            {
                var query = entities.Patientdatas.AsQueryable();
                if (!string.IsNullOrEmpty(searchInput))
                {
                    query = query.Where(p => p.FirstName.ToLower().Contains(searchInput.ToLower())||p.HealthIssues.ToLower().Contains(searchInput.ToLower()));
                }
                var totalCount = query.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var pagedPatients = query.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var viewModel = new
                {
                    Patients = pagedPatients,
                    TotalPages = totalPages
                };
                return Ok(viewModel);
            }
        }


        public Patientdata Get(int id)
        {
            using (HospitaldbEntities entities = new HospitaldbEntities())
            {
                return entities.Patientdatas.FirstOrDefault(x=>x.Id == id);
            }
        }
        public void Delete(int Id)
        {
            using (HospitaldbEntities entity = new HospitaldbEntities())
            {
                var patient = entity.Patientdatas.FirstOrDefault(p => p.Id == Id);
                if (patient != null)
                {
                    entity.Patientdatas.Remove(patient);
                    entity.SaveChanges();
                }
            }
        }
        
        public void Put(int id, [System.Web.Http.FromBody] Patientdata updatedPatient)
        {
            try
            {
                using (HospitaldbEntities entities = new HospitaldbEntities())
                {

                    // Find the patient with the specified ID in the database
                    var patient =  entities.Patientdatas.FirstOrDefault(x => x.Id == id);
                    // Update the patient data with the new values
                    patient.FirstName = updatedPatient.FirstName;
                    patient.LastName = updatedPatient.LastName;
                    patient.Gender = updatedPatient.Gender;
                    patient.HealthIssues = updatedPatient.HealthIssues;
                    patient.Address = updatedPatient.Address;
                    patient.City = updatedPatient.City;

                    // Save the changes to the database
                     entities.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error if there's an exception while updating the patient data
                
            }
        }


    }
}