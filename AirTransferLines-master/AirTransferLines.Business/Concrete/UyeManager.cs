using AirTransferLines.Business.Abstract;
using AirTransferLines.Business.Constants;
using AirTransferLines.DataAccess.Abstract;
using AirTransferLines.Entities.Concrete;
using AirTransferLines.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTransferLines.Business.Concrete
{
    public class UyeManager : IUyeService
    {
        IUyeDal _uyeDal;

        public UyeManager(IUyeDal uyeDal)
        {
            _uyeDal = uyeDal;
        }

        public IResult Add(Uye entity)
        {
            _uyeDal.Add(entity);
            return new SuccessResult(Messages.UyeAdded);
        }

        public IResult Delete(Uye entity)
        {
            _uyeDal.Delete(entity);
            return new SuccessResult(Messages.UyeDeleted);
        }

        

        public IDataResult<Uye> GetByID(int ID)
        {
            return new SuccessDataResult<Uye>(_uyeDal.Get(a => a.UlkeID == ID));
        }

        public IDataResult<List<UyeDTO>> GetUyeDetails()
        {
            return new SuccessDataResult<List<UyeDTO>>(_uyeDal.GetUyeDetails());
        }

        public IResult Update(Uye entity)
        {
            _uyeDal.Update(entity);
            return new SuccessResult(Messages.UyeUpdated);
        }
    }
}
