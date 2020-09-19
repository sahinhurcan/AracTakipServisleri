            //Verileri Doldurma
            DataTable dt = AracCekTrio();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AracModel yt = new AracModel();

                yt.Sayi = a + i + 1;
                yt.Plaka = dt.Rows[i]["license_plate"].ToString();
                yt.Enlem = dt.Rows[i]["longitude"].ToString();
                yt.Boylam = dt.Rows[i]["latitude"].ToString();
                yt.Sehir = "";
                yt.Firma = "TrioMobil";
                yt.CihazNo = "";
                string SF = yt.Plaka.Replace(" ", String.Empty);
                yt.Code = GirisKontrol.hash(SF.Trim(), true);
                yt.Code = yt.Code.Replace("+", "flash");
                ar.Add(yt);

            }

        //Verileri Çekme
        public static DataTable AracCekTrio()
        { 
            DataTable dt = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://takip.triomobil.com/soap/GetLastPositions?user="+"KULLANICIADI"+"&pass="+"SIFRE").Result;
                var Sonuc = response.Content.ReadAsStringAsync();

                

                dt = (DataTable)JsonConvert.DeserializeObject(Sonuc.Result, (typeof(DataTable)));

            }

            return dt;
        }
