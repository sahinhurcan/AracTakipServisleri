        
        //Elbobil veri çekme
        public static List<Result> AracCekElcobil()
        {
            
            List<Result> araclar = new List<Result>();
                            var token = "ELCOBILTOKEN";

                            var authValue = new AuthenticationHeaderValue("Bearer", token);

                            var client = new HttpClient()
                            {
                                DefaultRequestHeaders = { Authorization = authValue },

                            };


                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));


                            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get,
                                dr["Url"].ToString()+"/activity/last");


                            req.Headers.Add("Mobiliz-Token", token);

                            var task_Status = client.SendAsync(req).Result;
                            var Sonuc_Status = task_Status.Content.ReadAsStringAsync();

                            RootEcobil last = JsonConvert.DeserializeObject<RootEcobil>(Sonuc_Status.Result);
                            List<Result> son = last.result;

                            araclar.AddRange(son);
            return araclar;
        }
