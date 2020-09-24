using Final_Project_APWDN_SMS.Attributes;
using Final_Project_APWDN_SMS.Models;
using Final_Project_APWDN_SMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Project_APWDN_SMS.Controllers
{
    [RoutePrefix("api/superadmins")]
    
    public class SuperAdminController : ApiController
    {
        SuperAdminRepository suprepo = new SuperAdminRepository();
        AdminRepository adrepo = new AdminRepository();

        //SUPER ADMIN
        [Route("")]
        [SuperAuthorization]
        public IHttpActionResult GetSuperAdmin()
        {
            return Ok(suprepo.GetAll());
        }

        [Route("{id}", Name = "GetSuperById")]
        [SuperAuthorization]
        public IHttpActionResult GetSuperAdmin(int id)
        {
            SuperAdmin sp = suprepo.GetByID(id);
            if(sp == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(sp);
        }

        [Route("{id}")]
        [SuperAuthorization]
        public IHttpActionResult PutSuperAdmin([FromBody] SuperAdmin sp, [FromUri] int id)
        {
            sp.id = id;
            suprepo.Edit(sp);
            return Ok(sp);
        }

        //ADMIN

        [Route("admins")]
        [SuperAuthorization]
        public IHttpActionResult GetAdmin()
        {
            return Ok(adrepo.GetAll());
        }

        [Route("admins/{id}", Name = "Get_AdminById")]
        [SuperAuthorization]
        public IHttpActionResult GetAdmin(int id)
        {
            Admin a = adrepo.GetByID(id);
            if (a == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(a);
        }

        [Route("admins")]
        [SuperAuthorization]
        public IHttpActionResult PostAdmin(Admin s)
        {
            adrepo.Insert(s);
            string url = Url.Link("Get_AdminById", new { id = s.adminid });
            return Created(url, s);
        }

        [Route("admins/{id}")]
        [SuperAuthorization]
        public IHttpActionResult PutAdmin([FromBody] Admin a, [FromUri] int id)
        {
            a.id = id;
            adrepo.Edit(a);
            return Ok(a);
        }

        [Route("admins/{id}")]
        [SuperAuthorization]
        public IHttpActionResult DeleteAdmin(int id)
        {
            adrepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //GET NEW ADMIN ID FOR CREATE

        [Route("admins/new")]
        [SuperAuthorization]
        public IHttpActionResult GetNewAdminID()
        {
            return Ok(suprepo.GetNewID());
        }
    }
}
