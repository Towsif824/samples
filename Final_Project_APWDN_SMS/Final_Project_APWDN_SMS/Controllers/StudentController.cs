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
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        StudentRepository studrepo = new StudentRepository();
        Assignment_sRepository assrepo = new Assignment_sRepository();

        //STUDENT PROFILE

        [Route("{id}", Name = "Get_StudnetById")]
        //[StudentAuthorization]
        public IHttpActionResult GetStudent(int id)
        {
            Student s = studrepo.GetByID(id);
            if(s == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(s);
        }

        [Route("{id}")]
        //[StudentAuthorization]
        public IHttpActionResult PutStudent([FromBody] Student s, [FromUri] int id)
        {
            s.id = id;
            studrepo.Edit(s);
            return Ok(s);
        }


        //ASSIGNMENT

        //[Route("{id}/sections/{id2}/subjects/{id3}/assignments/s")]
        //[StudentAuthorization]
        //public IHttpActionResult GetAssignments([FromUri] int id, [FromUri] int id2)
        //{
        //    List<Assignment_s> a = assrepo.GetAssignmentsBySubjectsBySections(id, id2);
        //    if (a == null)
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //    return Ok(a);
        //}

        //[Route("{id}/sections/{id2}/subjects/{id3}/assignments/s/{id4}", Name = "GetAssignmentById")]
        //[StudentAuthorization]
        //public IHttpActionResult GetAssignment([FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        //{
        //    Assignment_s a = assrepo.GetAssignmentBySubjectsBySections(id, id2, id3);
        //    if (a == null)
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //    return Ok(a);
        //}

        //[Route("{id}/sections/{id2}/subjects/{id3}/assignments/s")]
        //[StudentAuthorization]
        //public IHttpActionResult PostAssignment([FromBody] Assignment_s a, [FromUri] int id, [FromUri] int id2)
        //{
        //    a.sectionid = id;
        //    a.subjectid = id2;
        //    assrepo.Insert(a);
        //    string url = Url.Link("GetAssignmentById", new { id = a.sectionid, id2 = a.subjectid, id3 = a.assignmentid });
        //    return Created(url, a);
        //}

        //[Route("{id}/sections/{id2}/subjects/{id3}/assignments/s/{id4}")]
        //[StudentAuthorization]
        //public IHttpActionResult PutAssignment([FromBody] Assignment_s a, [FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        //{
        //    a.sectionid = id;
        //    a.subjectid = id2;
        //    a.assignmentid = id3;
        //    assrepo.Edit(a);
        //    return Ok(a);
        //}

        //[Route("{id}/sections/{id}/subjects/{id2}/assignments/s/{id3}")]
        //[StudentAuthorization]
        //public IHttpActionResult DeleteAssignment([FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        //{
        //    assrepo.Delete(id3);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}
    }
}
