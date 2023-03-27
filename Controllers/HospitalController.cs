using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace WebApiOrionHospital.Controllers
{

    public class HospitalController : ApiController
    {
        // GET: Hospital
        [System.Web.Http.Authorize]
        public IEnumerable<Patientdata> Get(int page = 1, int pageSize = 10)
        {
            using (HospitaldbEntities entities = new HospitaldbEntities())
            {
                var skip = (page - 1) * pageSize;
                return entities.Patientdatas.ToList();
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
        
        public void Put(int id, [FromBody] Patientdata updatedPatient)
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