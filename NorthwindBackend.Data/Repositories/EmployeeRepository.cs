using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthwindBackend.Data.Context;
using NorthwindBackend.Data.Entities;
using NorthwindBackend.Domain.Entities;
using NorthwindBackend.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public EmployeeRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            var employeeMapped = _mapper.Map<Employee>(employee);

            return employeeMapped;
        }


    }
}
