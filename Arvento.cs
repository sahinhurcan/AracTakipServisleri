        //List e doldurma
        List<DtVehicleStatu> arv = AracArvento();

            for (int i = 0; i < arv.Count; i++)
            {
                AracModel yt = new AracModel();

                DtVehicleStatu ac = arv[i];

                yt.Sayi = a + i + 1;
                yt.Plaka = PlakaCek(ac.CihazX0020No);
                yt.Enlem = ac.Enlem;
                yt.Boylam = ac.Boylam;
                yt.Sehir = ac.Adres;
                yt.Firma = "Arvento";
                yt.CihazNo = ac.CihazX0020No;

                string SF = yt.Plaka.Replace(" ", String.Empty);
                yt.Code = GirisKontrol.hash(SF.Trim(), true);
                yt.Code = yt.Code.Replace("+", "flash");
                ar.Add(yt);

            }

        //Veriyi Çekme
        public static List<DtVehicleStatu> AracArvento()
            {
            List<DtVehicleStatu> araclar = new List<DtVehicleStatu>();

                    var response = client.GetAsync("http://ws.arvento.com/v1/report.asmx/GetVehicleStatus?Username="+ "KULLANICIADI" + "&PIN1="+"APIPIN1"+"&PIN2="+"APIPIN2" + "&Language=0").Result;
                                var Samochod = response.Content.ReadAsStringAsync();


                                XDocument doc = XDocument.Parse(Samochod.Result);

                           
                                foreach (XElement element in doc.Root.Elements())
                                {
                                    if (element.Name == "{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram")
                                    {
                                        foreach (XElement element2 in element.Elements())
                                        {

                                            foreach (XElement element3 in element2.Elements())
                                            {
                                                DtVehicleStatu arac = new DtVehicleStatu();
                                                foreach (XElement element4 in element3.Elements())
                                                {


                                                    if (element4.Name == "Cihaz_x0020_No")
                                                    {
                                                        arac.CihazX0020No = element4.Value;

                                                    }
                                                    else if (element4.Name == "Enlem")
                                                    {
                                                        //ÖZELLİKLE TERS YAPILDI DEĞİŞTİRME
                                                        arac.Boylam = element4.Value;


                                                    }
                                                    else if (element4.Name == "Boylam")
                                                    {   //ÖZELLİKLE TERS YAPILDI DEĞİŞTİRME
                                                        arac.Enlem = element4.Value;

                                                    }
                                                    else if (element4.Name == "Adres")
                                                    {
                                                        arac.Adres = element4.Value;

                                                    }
                                                    else if (element4.Name == "BinaX0020X002FX0020Bölge")
                                                    {
                                                        arac.BinaX0020X002FX0020Bölge = element4.Value;

                                                    }



                                                }


                                                araclar.Add(arac);
                                            }
                                        }

                                    }


                                }
            }   
