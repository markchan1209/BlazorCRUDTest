using System;
using AutoMapper;
using ToDoList.Data;
using ToDoList.DTO;

namespace ToDoList.Profiles
{
    public class StudentProfile : Profile
    {

        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>();
        }
    }
}
