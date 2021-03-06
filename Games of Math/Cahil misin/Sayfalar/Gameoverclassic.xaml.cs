﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using GoogleAds;

namespace Lord_of_the_Math.Sayfalar
{
    public partial class Gameoverclassic : PhoneApplicationPage
    {
        private InterstitialAd interstitialAd;
        IsolatedStorageSettings stroge;
        //reklam hazırlama
        private void OnRequestInterstitialClick()
        {
            // NOTE: Edit "MY_AD_UNIT_ID" with your interstitial
            // ad unit id.
            interstitialAd = new InterstitialAd("ca-app-pub-9952422283209342/4928163069");
            // NOTE: You can edit the event handler to do something custom here. Once the
            // interstitial is received it can be shown whenever you want.


            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = false;
            interstitialAd.LoadAd(adRequest);

            interstitialAd.ReceivedAd += İnterstitialAd_ReceivedAd;

        }


        //reklam hazırsa olacaklar
        private void İnterstitialAd_ReceivedAd(object sender, AdEventArgs e)
        {
           
            if (IsolatedStorageSettings.ApplicationSettings["reklam1"] == "0")
            {
                interstitialAd.ShowAd();
                IsolatedStorageSettings.ApplicationSettings["reklam"] = "0";
            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings["reklam"] = "2";
                IsolatedStorageSettings.ApplicationSettings.Save();
            }

        }

        public Gameoverclassic()
        {
            InitializeComponent();
            //reklamın farklı yerde gösterilmesini engelleme
            IsolatedStorageSettings.ApplicationSettings["reklam1"] = "0";
            IsolatedStorageSettings.ApplicationSettings.Save();
            //reklam gösterilsinmi ?
            if (IsolatedStorageSettings.ApplicationSettings["reklam"] == "2")
            {
                OnRequestInterstitialClick();
               
            }
            else
            {
                if (IsolatedStorageSettings.ApplicationSettings["reklam"] == "0")
                {
                    IsolatedStorageSettings.ApplicationSettings["reklam"] = "1";
                    IsolatedStorageSettings.ApplicationSettings.Save();
                }
                else if (IsolatedStorageSettings.ApplicationSettings["reklam"] == "1")
                {
                    IsolatedStorageSettings.ApplicationSettings["reklam"] = "2";
                    IsolatedStorageSettings.ApplicationSettings.Save();
                }


            }
            if (IsolatedStorageSettings.ApplicationSettings["nasıbitti"] == "1")
            {
                txt.Text = "Answer is wrong!";
            }
            if (IsolatedStorageSettings.ApplicationSettings["nasıbitti"] == "0")
            {
                txt.Text = "Time's up!";
            }
            stroge = IsolatedStorageSettings.ApplicationSettings;
            scrtxt.Text = IsolatedStorageSettings.ApplicationSettings["puan"].ToString();

            hangiscore();

        }
        //hangi zorluk seiyesi olduğunu gösteriyor
        public void hangiscore()
        {
            if (IsolatedStorageSettings.ApplicationSettings["puançarpanı"] == "1")
            {
                level.Text = "EASY";
                kolayscore();
            }
            else if (IsolatedStorageSettings.ApplicationSettings["puançarpanı"] == "2")
            {
                level.Text = "MEDİUM";
                ortascore();
            }
            else if (IsolatedStorageSettings.ApplicationSettings["puançarpanı"] == "3")
            {
                level.Text = "HARD";
                zorscore();
            }
        }

        public void kolayscore()
        {
            if (!stroge.Contains("hgkolaypuan1"))
            {

                IsolatedStorageSettings.ApplicationSettings["hgkolaypuan1"] = IsolatedStorageSettings.ApplicationSettings["puan"];
                IsolatedStorageSettings.ApplicationSettings.Save();
                hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgkolaypuan1"].ToString();
            }
            else
            {
                if (Convert.ToInt32(IsolatedStorageSettings.ApplicationSettings["hgkolaypuan1"]) < Convert.ToInt32(IsolatedStorageSettings.ApplicationSettings["puan"]))
                {
                    IsolatedStorageSettings.ApplicationSettings["hgkolaypuan1"] = IsolatedStorageSettings.ApplicationSettings["puan"];
                    IsolatedStorageSettings.ApplicationSettings.Save();
                    hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgkolaypuan1"].ToString();
                }
                else
                {
                    hstext.Visibility = Visibility.Collapsed;
                    hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgkolaypuan1"].ToString();
                }
            }
        }
        public void ortascore()
        {
            if (!stroge.Contains("hgortapuan1"))
            {

                IsolatedStorageSettings.ApplicationSettings["hgortapuan1"] = IsolatedStorageSettings.ApplicationSettings["puan"];
                IsolatedStorageSettings.ApplicationSettings.Save();
                hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgortapuan1"].ToString();
            }
            else
            {
                if (Convert.ToInt32(IsolatedStorageSettings.ApplicationSettings["hgortapuan1"]) < Convert.ToInt32(IsolatedStorageSettings.ApplicationSettings["puan"]))
                {
                    IsolatedStorageSettings.ApplicationSettings["hgortapuan1"] = IsolatedStorageSettings.ApplicationSettings["puan"];
                    IsolatedStorageSettings.ApplicationSettings.Save();
                    hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgortapuan1"].ToString();
                }
                else
                {
                    hstext.Visibility = Visibility.Collapsed;
                    hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgortapuan1"].ToString();
                }
            }
        }
        public void zorscore()
        {
            if (!stroge.Contains("hgzorpuan1"))
            {

                IsolatedStorageSettings.ApplicationSettings["hgzorpuan1"] = IsolatedStorageSettings.ApplicationSettings["puan"];
                IsolatedStorageSettings.ApplicationSettings.Save();
                hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgzorpuan1"].ToString();
            }
            else
            {
                if (Convert.ToInt32(IsolatedStorageSettings.ApplicationSettings["hgzorpuan1"]) < Convert.ToInt32(IsolatedStorageSettings.ApplicationSettings["puan"]))
                {
                    IsolatedStorageSettings.ApplicationSettings["hgzorpuan1"] = IsolatedStorageSettings.ApplicationSettings["puan"];
                    IsolatedStorageSettings.ApplicationSettings.Save();
                    hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgzorpuan1"].ToString();
                }
                else
                {
                    hstext.Visibility = Visibility.Collapsed;
                    hscrtxt.Text = IsolatedStorageSettings.ApplicationSettings["hgzorpuan1"].ToString();
                }
            }
        }
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["reklam1"] = "1";
            IsolatedStorageSettings.ApplicationSettings.Save();
            NavigationService.Navigate(new Uri("/Sayfalar/classicgamelevel.xaml", UriKind.Relative));
        }

        private void trybtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["reklam1"] = "1";
            IsolatedStorageSettings.ApplicationSettings.Save();
            NavigationService.Navigate(new Uri("/Sayfalar/classicgamelimitless.xaml", UriKind.Relative));
        }

        private void home_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["reklam1"] = "1";
            IsolatedStorageSettings.ApplicationSettings.Save();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void selectbtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["reklam1"] = "1";
            IsolatedStorageSettings.ApplicationSettings.Save();
            NavigationService.Navigate(new Uri("/Sayfalar/classicgamelevel.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_BackKeyPress_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["reklam1"] = "1";
            IsolatedStorageSettings.ApplicationSettings.Save();
            NavigationService.Navigate(new Uri("/Sayfalar/classicgamelevel.xaml", UriKind.Relative));
        }


    }
}