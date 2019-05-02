using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.TodoList.Interfaces;
using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.TodoList.Repository
{
    public class PeopleRepository : IPeopeRepo
    {
        private TodoListContext _context;
        public PeopleRepository(TodoListContext context)
        {
            _context = context;
        }
        public void Add(People parem)
        {
            _context.Peoples.Add(parem);
        }

        public void Delete(int id)
        {
            People person = FindByIdAsync(id).Result;
            if(person != null)
                _context.Peoples.Remove(person);
        }

        public IQueryable<People> FindAll()
        {
            return _context.Peoples;
        }

        public  Task<People> FindByIdAsync(int id)
        {
            return _context.Peoples.SingleOrDefaultAsync(people => people.Id == id);
        }

        public void Update(People param)
        {
            _context.Entry(param).State = EntityState.Modified;
        }
    }
}
