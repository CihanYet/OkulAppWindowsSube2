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
            Helper hlp = new Helper();
            int sonuc = hlp.ExecuteNonQuery($"Insert into tblOgrenciler(Ad,Soyad,Numara,TcKimlik,SinifId)values('{ogr.Ad}','{ogr.Soyad}','{ogr.Numara}','{ogr.Tckimlik}',{ogr.Sinifid})");
            return sonuc > 0;
        }
    }
}
