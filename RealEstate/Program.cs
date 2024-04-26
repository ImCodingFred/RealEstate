using System.Linq;

namespace RealEstate
{
    internal class Program
    {
        static List<ad> ads = new List<ad>();
        static List<category> categories = new List<category>();
        static List<seller> sellers = new List<seller>();
        static void Main(string[] args)
        {
            LoadCsv("realestates.csv");
            
            Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete: {ads.Where(x=>x.Floors==0).Average(x=>x.Area):0.00} m2");
            ad legvonalban = ads.FindAll(x=>x.FreeOfCharge==true).Find(x => x.DistanceTo(47.4164220114023, 19.066342425796986) == ads.FindAll(y=>y.FreeOfCharge==true).Min(y => y.DistanceTo(47.4164220114023, 19.066342425796986)));
            Console.WriteLine($"2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:" +
                $"\n\tEladó neve\t: {sellers[sellers.FindIndex(x=>x.Id== legvonalban.Seller)].Name}" +
                $"\n\tEladó telefonja: {sellers[sellers.FindIndex(x => x.Id == legvonalban.Seller)].Phone}" +
                $"\n\tAlapterület\t: {legvonalban.Area}" +
                $"\n\tSzobák száma\t: {legvonalban.Rooms}");
        }

        private static void LoadCsv(string input)
        {
            using (StreamReader sr = new(input))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] dbok = sr.ReadLine().Split(';');
                    string[] lat = dbok[2].Split(",");
                    (double lat, double longi) latlong = (double.Parse(lat[0].Replace('.',',')), double.Parse(lat[1].Replace('.', ',')));
                    ads.Add(new ad(int.Parse(dbok[0]), int.Parse(dbok[1]), (latlong.lat, latlong.longi),
                        int.Parse(dbok[3]), int.Parse(dbok[4]), dbok[5], int.Parse(dbok[6])==1?true:false, dbok[7],
                        DateTime.Parse(dbok[8]), int.Parse(dbok[9]), int.Parse(dbok[12])));
                    if (categories.Any(x => x.Id != int.Parse(dbok[12])))
                    {
                        categories.Add(new category(int.Parse(dbok[12]), dbok[12]));
                    }
                    sellers.Add(new seller(int.Parse(dbok[9]), dbok[10], dbok[11]));
                }
            }
        }
    }
}
