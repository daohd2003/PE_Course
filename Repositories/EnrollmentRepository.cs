using BussinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly Sp25Prn231Pe1Context _context;

        public EnrollmentRepository(Sp25Prn231Pe1Context context)
        {
            _context = context;
        }
        public async Task<bool> Enrollment(Enrollment entity)
        {
            try
            {
                await _context.Enrollments.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
