﻿using System;
using System.Text;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class MenuPrinter<T>
    {
        public void ShowMenu(IPrintable<T> printable)
        {
            if (printable is OptionsHandler)
            {
                OptionsHandler oh = printable as OptionsHandler;
                
                Console.WriteLine(oh.Progressable.Title);
                
                ProgressionWrapper pw = ProgressionHandlerFactory
                    .MakeProgressionHandler(oh.Progressable)
                    .GetProgression();
                Console.WriteLine(ProgressionBarHandler.GenerateProgressBar(pw));

                StringBuilder menuOptionsString = new();

                if (oh.IsFinishable)
                {
                    IFinishable f = oh.Progressable as IFinishable;
                    menuOptionsString.Append("[F] - Sett som ");
                    if (!f.Finished)
                    {
                        menuOptionsString.Append("ferdig\n");
                    }
                    else
                    {
                        menuOptionsString.Append("uferdig\n");
                    }
                }

                for (int i = 0; i < oh.Options.Count; i++)
                {
                    menuOptionsString.Append("["+(i+1)+"] - ");
                    menuOptionsString.Append(oh.Options[i].Title+"\n");
                }

                if (oh.SuperOption != null)
                {
                    menuOptionsString.Append("[0] - Tilbake til " + oh.SuperOption.Progressable.Title);
                }
                
                Console.WriteLine(menuOptionsString.ToString());
            }
            // else if (printable is LoginMenu)
            {
            }
        }

        
        public string AskForEmail()
        {
            Console.WriteLine("Vennligst skriv inn din e-post:");
            return Console.ReadLine();
        }

        public string AskForPassword()
        {
            Console.WriteLine("Vennligst skriv inn ditt passord:");
            return Console.ReadLine();
        }

        public void ErrorWithAuthentication()
        {
            Console.Clear();
            Logger.Instance.Write("Error with authentication");
            Console.WriteLine("Feil e-post eller passord. Prøv igjen.");
        }

        public void WelcomeMessage(string fullName)
        {
            Console.Clear();
            Console.WriteLine($"Velkommen {fullName}. Her er dine menyvalg:");
        }
    }
}