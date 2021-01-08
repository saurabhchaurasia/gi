using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeneralInsurance.Models;
using System.Web.Http.Cors;

namespace GeneralInsurance.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InsuranceController : ApiController
    {
        public HttpResponseMessage PostMotor([FromBody] MOTOR moto)
        {
            try
            {
                using (GeneralInsuranceEntities db = new GeneralInsuranceEntities())
                {
                    db.MOTORs.Add(moto);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, moto);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}