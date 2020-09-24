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
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        AdminRepository adrepo = new AdminRepository();
        TeacherRepository trepo = new TeacherRepository();
        SubjectRepository subrepo = new SubjectRepository();
        StudentRepository studrepo = new StudentRepository();
        SectionRepository secrepo = new SectionRepository();
        ClassRepository classrepo = new ClassRepository();
        GeneralNoticeRepository grepo = new GeneralNoticeRepository();

        // ADMIN

        [Route("{id}", Name = "GetAdminById")]
        //[AdminAuthorization]
        public IHttpActionResult GetAdmin(int id)
        {
            Admin a = adrepo.GetByID(id);
            if (a == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(a);
        }

        [Route("{id}")]
        //[AdminAuthorization]
        public IHttpActionResult PutAdmin([FromBody] Admin a, [FromUri] int id)
        {
            a.id = id;
            adrepo.Edit(a);
            return Ok(a);
        }

        //TEACHER

        [Route("teachers")]
        //[AdminAuthorization]
        public IHttpActionResult GetTeacher()
        {
            return Ok(trepo.GetAll());
        }

       [Route("teachers/{id}",Name="GetteacherById")]
        //[AdminAuthorization]
        public IHttpActionResult GetTeacher(int id)
        {
            Teacher t = trepo.GetByID(id);
            if(t == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(t);
        }

        [Route("teachers")]
        //[AdminAuthorization]
        public IHttpActionResult Post(Teacher t)
        {
            trepo.Insert(t);
            string url = Url.Link("GetTeacherById", new { id = t.teacherid });
            return Created(url, t);
        }

        [Route("teachers/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult PutTeacher([FromBody] Teacher t, [FromUri] int id)
        {
            t.id = id;
            trepo.Edit(t);
            return Ok(t);
        }

        [Route("teachers/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult DeleteTecher(int id)
        {
            trepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //STUDENT

        [Route("students")]
        //[AdminAuthorization]
        public IHttpActionResult GetStudent()
        {
            return Ok(studrepo.GetAll());
        }


        [Route("students/{id}", Name ="GetStudentById")]
        //[AdminAuthorization]
        public IHttpActionResult GetStudent(int id)
        {
            Student s = studrepo.GetByID(id);
            if (s ==  null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(s);
        }


        [Route("students")]
        //[AdminAuthorization]
        public IHttpActionResult PostStudent(Student s)
        {
            studrepo.Insert(s);
            string url = Url.Link("GetStudentById", new { id = s.studentid });
            return Created(url, s);
        }


        [Route("students/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult PutStudent([FromBody] Student s,[FromUri] int id)
        {
            s.id = id;
            studrepo.Edit(s);
            return Ok(s);
        }


        [Route("students/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult DeleteStudent(int id)
        {
            studrepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //CLASS

        [Route("classes")]
        //[AdminAuthorization]
        public IHttpActionResult GetClass()
        {
            return Ok(classrepo.GetAll());
        }

        [Route("classes/{id}", Name ="GetClassById")]
        //[AdminAuthorization]
        public IHttpActionResult GetClass(int id)
        {
            Class c = classrepo.GetByID(id);
            if (c == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(c);
        }


        [Route("classes")]
        //[AdminAuthorization]
        public IHttpActionResult PostClass(Class c)
        {
            classrepo.Insert(c);
            string url = Url.Link("GetClassById", new { id = c.classid });
            return Created(url, c);

        }


        [Route("classes/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult PutClass([FromBody] Class c, [FromUri] int id)
        {
            c.classid = id;
            classrepo.Edit(c);
            return Ok(c);
        }

        [Route("classes/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult DeleteClass(int id)
        {
            classrepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        //SECTION

        [Route("classes/{id}/sections")]
        //[AdminAuthorization]
        public IHttpActionResult GetSections([FromUri] int id)
        {
            List<Section> s = secrepo.GetSectionsByClass(id);
            if (s == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(s);
        }

        [Route("classes/{id}/sections/{id2}", Name = "GetSectionById")]
        //[AdminAuthorization]
        public IHttpActionResult GetSection([FromUri] int id, [FromUri] int id2)
        {
            Section s = secrepo.GetSectionByClass(id, id2);
            if (s == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(s);
        }

        [Route("classes/{id}/sections")]
        //[AdminAuthorization]
        public IHttpActionResult PostSection(Section s, [FromUri] int id)
        {
            s.classid = id;
            secrepo.Insert(s);
            string url = Url.Link("GetSectionById", new { id = s.classid, id2 = s.sectionid });
            return Created(url, s);
        }

        [Route("classes/{id}/sections/{id2}")]
        //[AdminAuthorization]
        public IHttpActionResult PutSection([FromBody] Section s, [FromUri] int id, [FromUri] int id2)
        {
            s.classid = id;
            s.sectionid = id2;
            secrepo.Edit(s);
            return Ok(s);
        }

        [Route("classes/{id}/sections/{id2}")]
        //[AdminAuthorization]
        public IHttpActionResult DeleteSection([FromUri] int id, [FromUri] int id2)
        {
            secrepo.Delete(id2);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //SUBJECT

        [Route("classes/{id}/subjects")]
        //[AdminAuthorization]
        public IHttpActionResult GetSubjects([FromUri] int id)
        {
            List<Subject> s = subrepo.GetSubjectsByClass(id);
            if (s == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(s);
        }

        [Route("classes/{id}/subjects/{id2}", Name = "GetSubjectById")]
        //[AdminAuthorization]
        public IHttpActionResult GetSubject([FromUri] int id, [FromUri] int id2)
        {
            Subject s = subrepo.GetSubjectByClass(id, id2);
            if (s == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(s);
        }

        [Route("classes/{id}/subjects")]
        //[AdminAuthorization]
        public IHttpActionResult PostSubject([FromBody] Subject s, [FromUri] int id)
        {
            s.classid = id;
            subrepo.Insert(s);
            string url = Url.Link("GetSubjectById", new { id = s.classid, id2 = s.subjectid });
            return Created(url, s);
        }

        [Route("classes/{id}/subjects/{id2}")]
        //[AdminAuthorization]
        public IHttpActionResult PutSubject([FromBody] Subject s, [FromUri] int id, [FromUri] int id2)
        {
            s.classid = id;
            s.subjectid = id2;
            subrepo.Edit(s);
            return Ok(s);
        }

        [Route("classes/{id}/subjects/{id2}")]
        //[AdminAuthorization]
        public IHttpActionResult Deletesubject([FromUri] int id, [FromUri] int id2)
        {
            subrepo.Delete(id2);
            return StatusCode(HttpStatusCode.NoContent);
        }


        //GET NEW TEACHER ID FOR CREATE

        [Route("teachers/new")]
        //[AdminAuthorization]
        public IHttpActionResult GetNewTeacherID()
        {
            return Ok(adrepo.GetNewTeacherID());
        }


        //GET NEW STUDENT ID FOR CREATE

        [Route("students/new")]
        //[AdminAuthorization]
        public IHttpActionResult GetNewStudentID()
        {
            return Ok(adrepo.GetNewStudentID());
        }


        //GENERAL NOTICES


        [Route("gnotices")]
        //[AdminAuthorization]
        public IHttpActionResult GetGeneralNotices()
        {
           List<GeneralNotice> g = grepo.GetAll();
            return Ok(g);
        }

        [Route("gnotices/{id}", Name ="GetGeneralNoticeById")]
        //[AdminAuthorization]
        public IHttpActionResult GetGeneralNotice(int id)
        {
            GeneralNotice g = grepo.GetByID(id);
            if (g == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(g);
        }

        [Route("gnotices")]
        //[AdminAuthorization]
        public IHttpActionResult PostGeneralNotice(GeneralNotice g)
        {
            grepo.Insert(g);
            string url = Url.Link("GetGeneralNoticeById", new { id = g.noticeid });
            return Created(url, g);
        }

        [Route("gnotices/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult PutGeneralNotice([FromBody] GeneralNotice g, [FromUri] int id)
        {
            g.noticeid = id;
            grepo.Edit(g);
            return Ok(g);
        }


        [Route("gnotices/{id}")]
        //[AdminAuthorization]
        public IHttpActionResult DeleteGeneralNotice(int id)
        {
            grepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        //URI TO GET ALL CLASSES & SECTIONS


        [Route("classes/sections")]
        //[AdminAuthorization]
        public IHttpActionResult GetAllClassesSections()
        {
            List<Section> s = secrepo.GetAll();
            if (s == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(s);
        }
    }
}
