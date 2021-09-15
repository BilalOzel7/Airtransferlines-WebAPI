using AirTransferLines.Core.DataAccess.EntityFramework;
using AirTransferLines.DataAccess.Abstract;
using AirTransferLines.Entities.Concrete;
using AirTransferLines.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTransferLines.DataAccess.Concrete.EntityFramework
{
   public class EfUyeDal : EfEntityRepositoryBase<Uye, AirTransferLinesContext>, IUyeDal
    {

        public List<UyeDTO> GetUyeDetails(Expression<Func<UyeDTO, bool>> filter = null)
        {
            using (AirTransferLinesContext context = new AirTransferLinesContext())
            {
                var result = from uye in context.Uyeler
                             join u in context.Ulkeler
                             on uye.UlkeID equals u.UlkeID
                             join se in context.Sehirler
                             on uye.SehirID equals se.SehirID
                            
                             select new UyeDTO
                             {

                                 UyeID=uye.UyeID,
                                 UyeAd=uye.UyeAd,
                                 UyeSoyad=uye.UyeSoyad,
                                 SehirID=uye.SehirID,
                                 SehirAd=se.SehirAd,
                                 UlkeID=uye.UlkeID,
                                 UlkeAd=u.UlkeAdi,
                                 Adres=uye.Adres,
                                 Email=uye.Email,
                                 Telefon=uye.Telefon,
                                 Sifre=uye.Sifre,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
