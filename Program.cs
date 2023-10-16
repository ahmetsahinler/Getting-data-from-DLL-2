using TxtDataRead;
namespace Program
{
    class Sıralama
    {
        public static void Main(string[] args)  
        {
            try{Veri veri = Veri.NesneVer(); veri.Verilerr();}
            catch(System.Text.Json.JsonException ex){Console.WriteLine(ex.Message);}
        }
    }
    class Veri
    {
        List<TxtDataRead.UserInfo> data;
        string path =@"C:\Users\Ahmet\Desktop\Odev7\bin\Okul.txt";
        private Veri(){this.data = DataThrow.Getir(path);}
        private static Veri? nesne;
        public static Veri NesneVer(){
            if (nesne==null){nesne = new Veri(); }
            return nesne;
        }
        public void Verilerr()
        {
            List<float> list = new List<float>();
            List<string> wrong = new List<string>();
            List<string> right = new List<string>();
            float a=0,sayac=0,sonuc=0,best = 0;
            string cop="";
            for (int i = 0; i < data.Count; i++){
                if (data[i].KatSayi>5 || data[i].KatSayi<1){
                    wrong.Add(data[i].Ogrenci+" Öğrencisinin "+data[i].Hafta + ". Haftasındaki kat sayısı yanlış girilmiştir..."); 
                }
                if (data[i].Hafta<=0){
                    wrong.Add(data[i].Ogrenci+" Öğrencisinin haftası yanlış girilmiştir...");
                }
                if (data[i].Puan<0 || data[i].Puan>100){
                    wrong.Add(data[i].Ogrenci+" Öğrencisinin "+data[i].Hafta + ". Haftasındaki puanı yanlış girilmiştir..."); 
                }
                if(cop != data[i].Ogrenci){
                cop = data[i].Ogrenci;
                    if (cop == data[i].Ogrenci){a += (data[i].Puan * data[i].KatSayi);sayac++;}
                sonuc =(a/sayac);
                list.Add(sonuc);
                right.Add(data[i].Ogrenci +" "+ sonuc);
                    if (sonuc > best){best = sonuc;}
                }else{continue;} 
            }
            if (wrong.Count>0){foreach (var item in wrong){Console.WriteLine(item);}
            }else{foreach (var item in right){Console.WriteLine(item);} 
            Console.WriteLine("------------------------------------------");
            list.Sort(); list.Reverse(); foreach (var item in list){Console.WriteLine(item);}}            
        }
        
    }

}