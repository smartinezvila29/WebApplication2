using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SolicitudeController : Controller
    {
        public string url = "http://localhost:8080";
        ApiConnect api = new ApiConnect();
        public IActionResult Index()
        {
            var responseSolicitudes = api.GetApi(url + "/solicitude/");
            List<SolicitudeDto> lstSolicitudesParsed = CastGetSolicitudes(responseSolicitudes);
            ViewBag.lstSolicitudes = lstSolicitudesParsed;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ApiConnect api = new ApiConnect();
            var responseClassroom = api.GetApi(url + "/classroom/");
            List<ClassroomDto> lstClass = CastListClassrooms(responseClassroom);
            var responseSubjects = api.GetApi(url + "/subject/");
            List<SubjectDto> lstSubjectParsed = CastListSubjects(responseSubjects);
            ViewBag.Classrooms = lstClass;
            ViewBag.Subjects = lstSubjectParsed;
            return View();
        }

        [HttpPost]
        public ActionResult Create(SolicitudeDto solicitude)
        {
            ClassroomDto classroom = new ClassroomDto();
            SubjectDto subjectDto = new SubjectDto();
            classroom.id = solicitude.classroomDtoNumber;
            subjectDto.id = solicitude.subjectDtoNumber;
            solicitude.subjectDto = subjectDto;
            solicitude.classroomDto = classroom;
            var json = JsonSerializer.Serialize(solicitude);
            json = json.Replace("subjectDto", "subjectEntity");
            json = json.Replace("classroomDto", "classroomEntity");
            ApiConnect api = new ApiConnect();
            api.PostApi(url + "/solicitude/", json);

            return View("Success");
        }

        public IActionResult Delete(int id)
        {
            ApiConnect api = new ApiConnect();
            var responseSolicitudes = api.DeleteFromApi(url + "/solicitude/" + id);
            if(responseSolicitudes.IsSuccessStatusCode)
            {
                return View("Success");
            }
            return View("Error");
        }


        public static List<ClassroomDto> CastListClassrooms(HttpResponseMessage responseClassroom)
        {
            var contents = responseClassroom.Content.ReadAsStringAsync().Result;
            ClassroomDto[] lstClassroom = JsonSerializer.Deserialize<ClassroomDto[]>(contents.ToString());
            List<ClassroomDto> lstClass = new List<ClassroomDto>();
            for (int i = 0; i < lstClassroom.Length; i++)
            {
                ClassroomDto classroom = lstClassroom[i];
                lstClass.Add(classroom);
            }

            return lstClass;
        }

        public static List<SubjectDto> CastListSubjects(HttpResponseMessage responseSubjects)
        {
            var contents = responseSubjects.Content.ReadAsStringAsync().Result;
            SubjectDto[] lstSubjects = JsonSerializer.Deserialize<SubjectDto[]>(contents.ToString());
            List<SubjectDto> lstSubjectParsed = new List<SubjectDto>();
            for (int i = 0; i < lstSubjects.Length; i++)
            {
                SubjectDto subjectDto = lstSubjects[i];
                lstSubjectParsed.Add(subjectDto);
            }
            return lstSubjectParsed;
        }

        public static List<SolicitudeDto> CastGetSolicitudes(HttpResponseMessage responseSolicitudes)
        {
            var contents = responseSolicitudes.Content.ReadAsStringAsync().Result;
            SolicitudeDto[] lstSolicitudes = JsonSerializer.Deserialize<SolicitudeDto[]>(contents.ToString());
            List<SolicitudeDto> lstSolicitudesParsed = new List<SolicitudeDto>();
            for (int i = 0; i < lstSolicitudes.Length; i++)
            {
                SolicitudeDto solicitude = lstSolicitudes[i];
                lstSolicitudesParsed.Add(solicitude);
            }

            return lstSolicitudesParsed;
        }
    }
}
