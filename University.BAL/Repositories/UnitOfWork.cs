
using System;
using University.Common.Models;
using University.DAL;

namespace University.BAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext context;
        private IStudentRepository studentRepository;
        private ICourseRepository courseRepository;
        private IGenericRepository<Department> departmentRepository;
        private IGenericRepository<Enrollment> enrollmentRepository;
        private IGenericRepository<Instructor> instructorRepository;


        public UnitOfWork(UniversityContext _context)
        {
            context = _context ?? throw new ArgumentNullException();
        }

        public IGenericRepository<Department> Department
        {
            get
            {
                if (departmentRepository == null)
                {
                    departmentRepository = new GenericRepository<Department>(context);
                }

                return departmentRepository;
            }
        }

        public IGenericRepository<Enrollment> Enrollment
        {
            get
            {
                if (enrollmentRepository == null)
                {
                    enrollmentRepository = new GenericRepository<Enrollment>(context);
                }

                return enrollmentRepository;
            }
        }

        public IGenericRepository<Instructor> Instructor
        {
            get
            {
                if (instructorRepository == null)
                {
                    instructorRepository = new GenericRepository<Instructor>(context);
                }

                return instructorRepository;
            }
        }
        public IStudentRepository Student
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepository(context);
                }

                return studentRepository;
            }
        }

        public ICourseRepository Course
        {
            get
            {
                if (courseRepository == null)
                {
                    courseRepository = new CourseRepository(context);
                }

                return courseRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
