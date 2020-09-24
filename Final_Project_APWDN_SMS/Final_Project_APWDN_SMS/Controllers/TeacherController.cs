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
    [RoutePrefix("api/teachers")]
    public class TeacherController : ApiController
    {
        TeacherRepository trepo = new TeacherRepository();
        SectionRepository secrepo = new SectionRepository();
        SubjectRepository subrepo = new SubjectRepository();
        Assignment_tRepository assrepo = new Assignment_tRepository();
        GradeRepository graderepo = new GradeRepository();
        CourseNoticeRepository courrepo = new CourseNoticeRepository();
        HomeworkRepository hrepo = new HomeworkRepository();
        UploadNoteRepository uprepo = new UploadNoteRepository();

        //TEACHER PROFILE

        [Route("{id}", Name = "Get_TeacherById")]
        //[TeacherAuthorization]
        public IHttpActionResult GetTeacher(int id)
        {
            Teacher t = trepo.GetByID(id);
            if (t == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(t);
        }

        [Route("{id}")]
        //[TeacherAuthorization]
        public IHttpActionResult PutTeacher([FromBody] Teacher t, [FromUri] int id)
        {
            t.id = id;
            trepo.Edit(t);
            return Ok(t);
        }

        //ASSIGNMENTS

        [Route("sections/{id}/subjects/{id2}/assignments/t")]
        //[TeacherAuthorization]
        public IHttpActionResult GetAssignments([FromUri] int id, [FromUri] int id2)
        {
            List<Assignment_t> a = assrepo.GetAssignmentsBySubjectsBySections(id, id2);
            if (a == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(a);
        }

        [Route("sections/{id}/subjects/{id2}/assignments/t/{id3}", Name = "GetAssignmentById")]
        //[TeacherAuthorization]
        public IHttpActionResult GetAssignment([FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        {
            Assignment_t a = assrepo.GetAssignmentBySubjectsBySections(id, id2, id3);
            if (a == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(a);
        }

        [Route("sections/{id}/subjects/{id2}/assignments/t")]
        //[TeacherAuthorization]
        public IHttpActionResult PostAssignment([FromBody] Assignment_t a, [FromUri] int id, [FromUri] int id2)
        {
            a.sectionid = id;
            a.subjectid = id2;
            assrepo.Insert(a);
            string url = Url.Link("GetAssignmentById", new { id = a.sectionid, id2 = a.subjectid, id3 = a.assignmentid });
            return Created(url, a);
        }

        [Route("sections/{id}/subjects/{id2}/assignments/t/{id3}")]
        //[TeacherAuthorization]
        public IHttpActionResult PutAssignment([FromBody] Assignment_t a, [FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        {
            a.sectionid = id;
            a.subjectid = id2;
            a.assignmentid = id3;
            assrepo.Edit(a);
            return Ok(a);
        }

        [Route("sections/{id}/subjects/{id2}/assignments/t/{id3}")]
        //[TeacherAuthorization]
        public IHttpActionResult DeleteAssignment([FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        {
            assrepo.Delete(id3);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //GRADES

        [Route("sections/{id}/subjects/{id2}/grades")]
        //[TeacherAuthorization]
        public IHttpActionResult GetGrades([FromUri] int id, [FromUri] int id2)
        {
            List<Grade> g = graderepo.GetGradesBySectionsBySubjects(id, id2);
            if (g == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(g);
        }


        [Route("sections/{id}/subjects/{id2}/grades/{id3}", Name = "GetGradeById")]
        //[TeacherAuthorization]
        public IHttpActionResult GetGrade([FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        {
            Grade g = graderepo.GetGradeBySectionsBySubjects(id, id2, id3);
            if (g == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(g);
        }


        [Route("sections/{id}/subjects/{id2}/grades")]
        //[TeacherAuthorization]
        public IHttpActionResult PostGrade([FromBody] Grade g, [FromUri] int id, [FromUri] int id2)
        {
            g.sectionid = id;
            g.subjectid = id2;
            graderepo.Insert(g);
            string url = Url.Link("GetGradeById", new { id = g.sectionid, id2 = g.subjectid, id3 = g.gradeid });
            return Created(url, g);
        }


        [Route("sections/{id}/subjects/{id2}/grades/{id3}")]
        //[TeacherAuthorization]
        public IHttpActionResult PutGrade([FromBody] Grade g, [FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        {
            g.sectionid = id;
            g.subjectid = id2;
            g.gradeid = id3;
            graderepo.Edit(g);
            return Ok(g);
        }


        [Route("sections/{id}/subjects/{id2}/grades/{id3}")]
        //[TeacherAuthorization]
        public IHttpActionResult DeleteGrade([FromUri] int id, [FromUri] int id2, [FromUri] int id3)
        {
            graderepo.Delete(id3);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //COURSE NOTICE

        [Route("classes/{id}/sections/{id1}/subjects/{id2}/cnotices")]
        //[TeacherAuthorization]
        public IHttpActionResult GetCourseNotices([FromUri] int id, [FromUri] int id1, [FromUri] int id2)
        {
            List<CourseNotice> c = courrepo.GetNoticesByClassSectionSubject(id, id1, id2);
            if(c == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(c);

        }

        [Route("classes/{id}/sections/{id1}/subjects/{id2}/cnotices/{id3}", Name ="GetCourseNoticeById")]
        //[TeacherAuthorization]
        public IHttpActionResult GetCourseNotice([FromUri] int id, [FromUri] int id1, [FromUri] int id2, [FromUri] int id3)
        {
            CourseNotice c = courrepo.GetNoticeByClassSectionSubject(id, id1, id2, id3);
            {
                if(c == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                return Ok(c);
            }
        }

        [Route("classes/{id}/sections/{id1}/subjects/{id2}/cnotices")]
        //[TeacherAuthorization]
        public IHttpActionResult PostCourseNotice([FromBody] CourseNotice c, [FromUri] int id, [FromUri] int id1, [FromUri] int id2 )
        {
            c.classid = id;
            c.sectionid = id1;
            c.subjectid = id2;
            courrepo.Insert(c);
            string url = Url.Link("GetCourseNoticeById", new { id = c.classid, id1 = c.sectionid, id2 = c.subjectid, id3 = c.noticeid });
            return Created(url, c);
        }

        [Route("classes/{id}/sections/{id1}/subjects/{id2}/cnotices/{id3}")]
        //[TeacherAuthorization]
        public IHttpActionResult PutCourseNotice([FromBody] CourseNotice c, [FromUri] int id, [FromUri] int id1, [FromUri] int id2, [FromUri] int id3)
        {
            c.classid = id;
            c.sectionid = id1;
            c.subjectid = id2;
            c.noticeid = id3;
            courrepo.Edit(c);
            return Ok(c);
        }

        [Route("classes/{id}/sections/{id1}/subjects/{id2}/cnotices/{id3}")]
        //[TeacherAuthorization]
        public IHttpActionResult DeleteCourseNotice([FromUri] int id, [FromUri] int id1, [FromUri] int id2, [FromUri] int id3)
        {
            courrepo.Delete(id3);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //HOME WORK

        [Route("sections/{id}/subjects/{id1}/homeworks")]
        //[TeacherAuthorization]
        public IHttpActionResult GetHomeworks([FromUri] int id, [FromUri] int id1)
        {
            List<Homework> h = hrepo.GetHomeworskBySectionSubject(id, id1);
            if(h == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(h);
        }

        [Route("sections/{id}/subjects/{id1}/homeworks/{id2}", Name = "GetHomewrokById")]
        //[TeacherAuthorization]
        public IHttpActionResult GetHomework([FromUri] int id, [FromUri] int id1, [FromUri] int id2)
        {
            Homework h = hrepo.GetHomeworkBySectionSubject(id, id1, id2);
            if(h == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(h);
        }

        [Route("sections/{id}/subjects/{id1}/homeworks")]
        //[TeacherAuthorization]
        public IHttpActionResult PostHomework([FromBody] Homework h, [FromUri] int id, [FromUri] int id1)
        {
            h.sectionid = id;
            h.subjectid = id1;
            hrepo.Insert(h);
            string url = Url.Link("GetHomewrokById", new { id = h.sectionid, id1 = h.subjectid, id2 = h.homeworkid });
            return Created(url, h);
        }

        [Route("sections/{id}/subjects/{id1}/homeworks/{id2}")]
        //[TeacherAuthorization]
        public IHttpActionResult PutHomework([FromBody] Homework h, [FromUri] int id, [FromUri] int id1, [FromUri] int id2)
        {
            h.sectionid = id;
            h.subjectid = id1;
            h.homeworkid = id2;
            hrepo.Edit(h);
            return Ok(h);
        }
        [Route("sections/{id}/subjects/{id1}/homeworks/{id2}")]
        //[TeacherAuthorization]
        public IHttpActionResult DeleteHomework([FromUri] int id2)
        {
            hrepo.Delete(id2);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // UPLOAD NOTE

        [Route("sections/{id}/subjects/{id1}/notes")]
        //[TeacherAuthorization]
        public IHttpActionResult GetUploadNote([FromUri] int id, [FromUri] int id1)
        {
            List<UploadNote> up = uprepo.GetUploadNotes(id,id1);
            if(up == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(up);
        }

        [Route("sections/{id}/subjects/{id1}/notes/{id2}", Name ="GetUplaodById")]
        //[TeacherAuthorization]
        public IHttpActionResult GetUploadNote([FromUri] int id, [FromUri] int id1, [FromUri] int id2)
        {
            UploadNote up = uprepo.GetUploadNote(id, id1, id2);
            if (up == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(up);
        }

        [Route("sections/{id}/subjects/{id1}/notes")]
        //[TeacherAuthorization]
        public IHttpActionResult PostUploadNote([FromBody] UploadNote up, [FromUri] int id, [FromUri] int id1 )
        {
            up.sectionid = id;
            up.subjectid = id1;
            uprepo.Insert(up);
            string url = Url.Link("GetUplaodById", new { id = up.sectionid, id1 = up.subjectid, id2 = up.uploadid });
            return Created(url, up);
        }

        [Route("sections/{id}/subjects/{id1}/notes/{id2}")]
        //[TeacherAuthorization]
        public IHttpActionResult PutUploadNote([FromBody] UploadNote up, [FromUri] int id, [FromUri] int id1, [FromUri] int id2)
        {
            up.sectionid = id;
            up.subjectid = id1;
            up.uploadid = id2;
            uprepo.Edit(up);
            return Ok(up);
        }

        [Route("sections/{id}/subjects/{id1}/notes/{id2}")]
        //[TeacherAuthorization]
        public IHttpActionResult DeleteUploadNote([FromUri] int id2)
        {
            uprepo.Delete(id2);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
