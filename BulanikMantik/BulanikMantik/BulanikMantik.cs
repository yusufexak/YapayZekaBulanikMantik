using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantik
{
    class BulanikMantik
    {
        //hassaslık
        const string h_hassas = "Hassas", h_orta = "Orta", h_saglam = "Saglam";
        //miktar
        const string m_buyuk = "Buyuk", m_orta = "Orta", m_kucuk = "Kucuk";
        //kirlilik
        const string k_buyuk = "Buyuk", k_orta = "Orta", k_kucuk = "Kucuk";
        //Deterjan
        const string d_cok_az = "Cok Az", d_az = "Az", d_orta = "Orta", d_fazla = "Fazla", d_cok_fazla = "Cok Fazla";
        //Süre
        const string s_kisa = "Kisa", s_normal_kisa = "Normal Kisa", s_orta = "Orta", s_normal_uzun = "Normal Uzun", s_uzun = "Uzun";
        //Dünüş hız
        const string dh_hassas = "Hassas", dh_normal_hassas = "Normal Hassas", dh_orta = "Orta", dh_normal_guclu = "Normal Guclu", dh_guclu = "Guclu";


        List<Kural> kurallar = new List<Kural>();
        List<Kural> secilen = new List<Kural>();
        List<string> hassaslik_list = new List<string>();
        List<string> kirlilik_list = new List<string>();
        List<string> miktar_list = new List<string>();
        List<double> mandani_hesaplari = new List<double>();
        List<double> temp_mandani = new List<double>();
        double hassaslik, miktar, kirlilik;

        public List<Kural> liste()
        {
            kurallar.Add(new Kural(h_hassas, m_kucuk, k_kucuk, dh_hassas, s_kisa, d_cok_az));
            kurallar.Add(new Kural(h_hassas, m_kucuk, k_orta, dh_normal_hassas, s_kisa, d_az));
            kurallar.Add(new Kural(h_hassas, m_kucuk, k_buyuk, dh_orta, s_normal_kisa, d_orta));
            //4
            kurallar.Add(new Kural(h_hassas, m_orta, k_kucuk, dh_hassas, s_kisa, d_orta));
            kurallar.Add(new Kural(h_hassas, m_orta, k_orta, dh_normal_hassas, s_normal_kisa, d_orta));
            kurallar.Add(new Kural(h_hassas, m_orta, k_buyuk, dh_orta, s_orta, d_fazla));
            //7
            kurallar.Add(new Kural(h_hassas, m_buyuk, k_kucuk, dh_normal_hassas, s_normal_kisa, d_orta));
            kurallar.Add(new Kural(h_hassas, m_buyuk, k_orta, dh_normal_hassas, s_orta, d_fazla));
            kurallar.Add(new Kural(h_hassas, m_buyuk, k_buyuk, dh_orta, s_normal_uzun, d_fazla));
            //10
            kurallar.Add(new Kural(h_orta, m_kucuk, k_kucuk, dh_normal_hassas, s_normal_kisa, d_az));
            kurallar.Add(new Kural(h_orta, m_kucuk, k_orta, dh_orta, s_kisa, d_orta));
            kurallar.Add(new Kural(h_orta, m_kucuk, k_buyuk, dh_normal_guclu, s_orta, d_fazla));
            //13
            kurallar.Add(new Kural(h_orta, m_orta, k_kucuk, dh_normal_hassas, s_normal_kisa, d_orta));
            kurallar.Add(new Kural(h_orta, m_orta, k_orta, dh_orta, s_orta, d_orta));
            kurallar.Add(new Kural(h_orta, m_orta, k_buyuk, dh_hassas, s_uzun, d_fazla));
            //16
            kurallar.Add(new Kural(h_orta, m_buyuk, k_kucuk, dh_hassas, s_orta, d_orta));
            kurallar.Add(new Kural(h_orta, m_buyuk, k_orta, dh_hassas, s_normal_uzun, d_fazla));
            kurallar.Add(new Kural(h_orta, m_buyuk, k_buyuk, dh_hassas, s_uzun, d_cok_fazla));
            //19
            kurallar.Add(new Kural(h_saglam, m_kucuk, k_kucuk, dh_orta, s_orta, d_az));
            kurallar.Add(new Kural(h_saglam, m_kucuk, k_orta, dh_normal_guclu, s_orta, d_orta));
            kurallar.Add(new Kural(h_saglam, m_kucuk, k_buyuk, dh_guclu, s_normal_uzun, d_fazla));
            //22
            kurallar.Add(new Kural(h_saglam, m_orta, k_kucuk, dh_orta, s_orta, d_orta));
            kurallar.Add(new Kural(h_saglam, m_orta, k_orta, dh_normal_guclu, s_normal_uzun, d_orta));
            kurallar.Add(new Kural(h_saglam, m_orta, k_buyuk, dh_guclu, s_orta, d_cok_fazla));
            //25
            kurallar.Add(new Kural(h_saglam, m_buyuk, k_kucuk, dh_normal_guclu, s_normal_uzun, d_fazla));
            kurallar.Add(new Kural(h_saglam, m_buyuk, k_orta, dh_normal_guclu, s_uzun, d_fazla));
            kurallar.Add(new Kural(h_saglam, m_buyuk, k_buyuk, dh_guclu, s_uzun, d_cok_fazla));
            return kurallar;
        }

        public List<Kural> aralikdegerlendirme(double hassaslik, double miktar, double kirlilik)
        {
            hassaslik_list.Clear();
            kirlilik_list.Clear();
            miktar_list.Clear();
            mandani_hesaplari.Clear();
            temp_mandani.Clear();
            secilen.Clear();
            
            this.hassaslik = hassaslik;
            this.miktar = miktar;
            this.kirlilik = kirlilik;

            hassaslik_metod(hassaslik);
            miktar_metod(miktar);
            kirlilik_metod(kirlilik);

            for (int i = 0; i < hassaslik_list.Count; i++)
            {
                for (int j = 0; j < miktar_list.Count; j++)
                {
                    for (int k = 0; k < kirlilik_list.Count; k++)
                    {
                        foreach (Kural item in kurallar)
                        {
                            if (item.hassaslik == hassaslik_list[i] && item.miktar == miktar_list[j] && item.kirlilik == kirlilik_list[k])
                            {
                                secilen.Add(item);
                            }
                        }
                    }
                }
            }
            return secilen;
        }



        private void hassaslik_metod(double hassaslik)
        {
            if (hassaslik <= 4)
            {
                hassaslik_list.Add(h_saglam);
            }
            if (hassaslik >= 3 && hassaslik <= 7)
            {
                hassaslik_list.Add(h_orta);
            }
            if (hassaslik >= 5.5)
            {
                hassaslik_list.Add(h_hassas);
            }
        }
        private void miktar_metod(double miktar)
        {
            if (miktar <= 4)
            {
                miktar_list.Add(m_kucuk);
            }
            if (miktar >= 3 && miktar <= 7)
            {
                miktar_list.Add(m_orta);
            }
            if (miktar >= 5.5)
            {
                miktar_list.Add(m_buyuk);
            }
        }
        private void kirlilik_metod(double kirlilik)
        {
            if (kirlilik <= 4.5)
            {
                kirlilik_list.Add(k_kucuk);
            }
            if (kirlilik >= 3 && kirlilik <= 7)
            {
                kirlilik_list.Add(k_orta);
            }
            if (kirlilik >= 5.5)
            {
                kirlilik_list.Add(k_buyuk);
            }
        }


        double sekil(double a, double b, double c, double d, double deger)
        {
            if (deger >= a && deger <= b)
            {
                return (deger - a) / (b - a);
            }
            if (deger >= c && deger <= d)
            {
                return (deger - c) / (c - d) + 1;
            }
            return 1;
        }
        double fx_hassaslik(string hassaslik, double deger)
        {
            switch (hassaslik)
            {
                case h_saglam:
                    return sekil(-4, -1.5, 2, 4, deger);
                case h_orta:
                    return sekil(3, 5, 5, 7, deger);
                default:
                    return sekil(5.5, 8, 12.5, 14, deger);
            }

        }
        double fx_miktar(string miktar, double deger)
        {
            switch (miktar)
            {
                case m_kucuk:
                    return sekil(-4, -1.5, 2, 4, deger);
                case m_orta:
                    return sekil(3, 5, 5, 7, deger);
                default:
                    return sekil(5.5, 8, 12.5, 14, deger);
            }

        }
        double fx_kirlilik(string kirlilik, double deger)
        {
            switch (kirlilik)
            {
                case k_kucuk:
                    return sekil(-4.5, -2.5, 2, 4.5, deger);
                case k_orta:
                    return sekil(3, 5, 5, 7, deger);
                default:
                    return sekil(5.5, 8, 12.5, 15, deger);
            }

        }
        public List<double> mandani()
        {
            
            mandani_hesaplari.Clear();
            foreach (var item in secilen)
            {
                temp_mandani.Clear();
                temp_mandani.Add(fx_hassaslik(item.hassaslik, hassaslik));
                temp_mandani.Add(fx_miktar(item.miktar, miktar));
                temp_mandani.Add(fx_kirlilik(item.kirlilik, kirlilik));
                mandani_hesaplari.Add(temp_mandani.Min());
            }
            max_bul();
            return mandani_hesaplari;
        }
        double[] max_donushizi;
        double[] max_sure;
        double[] max_deterjan;
        string[] donus_hizi_dizi = new string[] { dh_hassas, dh_normal_hassas, dh_orta, dh_normal_guclu, dh_guclu };
        string[] sure_dizi = new string[] { s_kisa, s_normal_kisa, s_orta, s_normal_uzun, s_uzun };
        string[] deterjan_dizi = new string[] { d_cok_az, d_az, d_orta, d_fazla, d_cok_fazla };
        public double[] max_bul()
        {
            max_donushizi = new double[5];
            max_sure = new double[5];
            max_deterjan = new double[5];
            for (int i = 0; i < secilen.Count; i++)
            {
                for (int j = 0; j < donus_hizi_dizi.Length; j++)
                {
                    if (secilen[i].donus_hizi == donus_hizi_dizi[j])
                    {
                        if (max_donushizi[j] < mandani_hesaplari[i])
                        {
                            max_donushizi[j] = mandani_hesaplari[i];
                        };

                    }
                    if (secilen[i].sure == sure_dizi[j])
                    {
                        if (max_sure[j] < mandani_hesaplari[i])
                        {
                            max_sure[j] = mandani_hesaplari[i];
                        };

                    }
                    if (secilen[i].deterjan == deterjan_dizi[j])
                    {
                        if (max_deterjan[j] < mandani_hesaplari[i])
                        {
                            max_deterjan[j] = mandani_hesaplari[i];
                        };

                    }
                }
            }

            return agirlik_ortama();
        }

        private double[] agirlik_ortama()
        {
            double deterjan = 0;
            double donus_hizi = 0;
            double sure = 0;
            double t_deterjan = 0;
            double t_donus_hizi = 0;
            double t_sure = 0;

            donus_hizi = max_donushizi[0] * 0.514 +
                            max_donushizi[1] * 2.75 +
                            max_donushizi[2] * 5 +
                            max_donushizi[3] * 7.25 +
                            max_donushizi[4] * 9.5;
            sure = max_sure[0] * 22.3 +
                           max_sure[1] * 39.9 +
                           max_sure[2] * 57.5 +
                           max_sure[3] * 75.1 +
                           max_sure[4] * 92.7;
            deterjan = max_deterjan[0] * 20 +
                            max_deterjan[1] * 85 +
                            max_deterjan[2] * 150 +
                            max_deterjan[3] * 215 +
                            max_deterjan[4] * 270;
            for (int i = 0; i < max_donushizi.Length; ++i)
            {
                t_donus_hizi += max_donushizi[i];
                t_sure += max_sure[i];
                t_deterjan += max_deterjan[i];
            }
            double h_detarjan = deterjan / t_deterjan;
            double h_donus_hizi = donus_hizi / t_donus_hizi;
            double h_sure = sure / t_sure;
            double[] degerler = new double[] { h_detarjan, h_donus_hizi, h_sure };
            return degerler;
        }

    }
}
