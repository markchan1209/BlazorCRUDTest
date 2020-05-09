using System;
using AutoMapper;
using ToDoList.DTO;
using ToDoList.Profiles;

namespace ToDoList.Data
{
    public class Student
    {
        IMapper _mapper;

        public int StudentID { get; set; }

        public string  Name { get; set; }

        public int Roll { get; set; }

        public StudentDTO GetStudentDTOObject()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<StudentProfile>();
            });

            _mapper = config.CreateMapper();

            var student = new Student();
            student.StudentID = 3;
            student.Name = "TEST";
            student.Roll = 1001;

            var studentDTO = _mapper.Map<StudentDTO>(student);
            return studentDTO;
        }
    }
}
