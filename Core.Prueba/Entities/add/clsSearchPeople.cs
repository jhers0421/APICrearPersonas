using Core.Prueba.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Prueba.Entities.add
{
    public class clsSearchPeople
    {
        public List<PeopleDto>? PeopleDto { get; set; }
        public List<PatientsDto>? PatientsDto { get; set; }
        public List<MasterdataDto>? MasterdataDto { get; set; }
    }
}
