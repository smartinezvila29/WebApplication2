using System;
namespace WebApplication2.Models
{
    public class SolicitudeDto
    {
        public int id { get; set; }
        public DateTime solicitudeDate { get; set; }
        public int studentsQuantity { get; set; }
        public SubjectDto subjectDto { get; set; }
        public int subjectDtoNumber { get; set; }
        public int classroomDtoNumber { get; set; }
        public string observations { get; set; }   
        public int solicitudeCode { get; set; }
        public string typeSolicitude { get; set; }
        public string shiftEntity { get; set; }
        public DateTime startDate { get; set; }    
        public DateTime endDate { get; set; }  
        public ClassroomDto classroomDto { get; set; }
    }
}
