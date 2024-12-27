using dav33.Data;
using dav33.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace dav33.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll(
            Expression<Func<Student, bool>> filter = null,
            Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null)
        {
            IQueryable<Student> query = _context.Students;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Insert(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Student student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}