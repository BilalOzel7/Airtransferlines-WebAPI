using AirTransferLines.Core.DataAccess;
using AirTransferLines.Entities.Concrete;
using AirTransferLines.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTransferLines.DataAccess.Abstract
{
   public interface IUyeDal: IEntityRepository<Uye>
    {
        List<UyeDTO> GetUyeDetails(Expression<Func<UyeDTO, bool>> filter = null);
    }
}
