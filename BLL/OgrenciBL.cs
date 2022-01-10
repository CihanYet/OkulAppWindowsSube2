using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OgrenciBL
    {
        public bool OgrenciEkle(Ogrenci ogr)
        {            
            if (ogr==null)
            {
                throw new NullReferenceException("Ogrenci Eklerken Referans Null Geldi");
            }

            try
            {
                Helper hlp = new Helper();
                int sonuc = hlp.ExecuteNonQuery($"Insert into tblOgrenciler(Ad,Soyad,Numara,TcKimlik,SinifId)values('{ogr.Ad}','{ogr.Soyad}','{ogr.Numara}','{ogr.Tckimlik}',{ogr.Sinifid})");
                return sonuc > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool OgrenciGuncelle(Ogrenci ogr)
        {
            if (ogr == null)
            {
                throw new NullReferenceException("Ogrenci Güncellerken Referans Null Geldi");
            }

            try
            {
                Helper hlp = new Helper();
                int sonuc = hlp.ExecuteNonQuery($"Update tblOgrenciler set Ad='{ogr.Ad}',Soyad='{ogr.Soyad}',Numara='{ogr.Numara}',Sinifid={ogr.Sinifid} where OgrenciId={ogr.Ogrenciid}");
                return sonuc > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
