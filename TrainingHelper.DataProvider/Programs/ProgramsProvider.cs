using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Core.DbConnection;
using TrainingHelper.Core.ModelConverter;
using TrainingHelper.Models.Exercises;
using TrainingHelper.Models.Programs;

namespace TrainingHelper.DataProvider.Programs
{
    public class ProgramsProvider:IDisposable
    {
        private DatabaseEntities _db;

        public ProgramsProvider()
        {
            _db = new DatabaseEntities();
        }
        #region create

        #endregion


        #region Get

        public async Task<IEnumerable<ShortProgram>> GetUserPrograms(int userId)
        {
            var progs = await _db.UserToProgram.Where(utp => utp.UserId == userId).Select(utp => utp.TrainingProgram).ToListAsync();
            return progs.ToShortPrograms();
        }

        public async Task<IEnumerable<ShortProgram>> GetAllPrograms()
        {
            var list = await _db.TrainingProgram.ToListAsync();
            return list.ToShortPrograms();
        }

        #endregion


        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
