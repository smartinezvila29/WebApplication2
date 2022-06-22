using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class ClassroomDto
    {
        public int id { get; set; }
        public int number { get; set; }
        public int quantityOfChairs { get; set; }
        public int quantityOfPC { get; set; }
        public string typeClassroom { get; set; }
        public bool blackboard { get; set; }
        public BuildingEntity buildingEntity { get; set; }
    }


}
