        public static List<Vehicle> AracCek()
        {
            List<Vehicle> arac = null;
            using (var client = new HttpClient())
            {

                var response = client.GetAsync("http://api.satko.com.tr/request.php?id="+"IDBILGISI"+":89&hash="+"HASHBILGISI"+"&requestId=7&timeFormat=1").Result;
                var Sonuc = response.Content.ReadAsStringAsync();
                Root JsonSinif = JsonConvert.DeserializeObject<Root>(Sonuc.Result);
                arac = JsonSinif.response.vehicles;

                for (int i = 0; i < arac.Count; i++)
                {

                    string[] dizi = arac[i].latest_position.REFERENCE.Split(' ');



                    int al = dizi.Length - 1;

                    try
                    {
                        arac[i].latest_position.Sehir = dizi[al - 1] + dizi[al];
                    }
                    catch
                    {
                        try
                        {

                            string[] dizi2 = arac[i].latest_position.REFERENCE.Split(',');
                            int al2 = dizi2.Length - 1;
                            arac[i].latest_position.Sehir = dizi2[al2 - 1] + dizi2[al2];
                        }
                        catch
                        {

                        }
                    }

                    arac[i].SayPlaka = i + 1;
                }

            }

            return arac;
        }
