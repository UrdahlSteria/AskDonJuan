using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskDonJuan.Models
{
    public class ResponseModel
    {

        // Innser at disse introduksjoene fungrerer i veldig forskjellige situasjoner
        public List<string> Intro = new List<string>() {
            "Du, jeg har tenkt litt ",
            "Hei, hør her... ",
            "Vi må snakke sammen... Eller, jeg har noe jeg vil si. ",
            "Jeg har noe jeg trenger å få at hjertet. ",
            "Jeg vil ikke såre deg, men, " };

        public List<string> GoodResponse = new List<string>() {
            "Du er en utrolig kul jente som det har vært kjempegøy å være sammen med, men kjenner at det ikke føler helt riktig. Tenkte kanskje at det var greit å si ifra, før enn senere. ",
            "Vi har hatt det veldig gøy sammen i det siste, men tror ikke dette går noen steder, om du skjønner? ",
            "Jeg har lyst til å møte deg mer, men kjenner at jeg må rydde opp i noen greier i livet mitt først, så tror ikke vi kan treffes lengre. ",
             };

        public List<string> NormalReponse = new List<string>() {
            "Vi har hatt det gøy sammen, men jeg har ikke tid til det lengre. Jeg må gjøre andre ting. ",
            "Du har vært topp, men dette går ingen steder. ",
            };

        public List<string> BadResponse = new List<string>() {
            "Jeg skjønner ikke hva jeg tenkte da jeg hooket opp med en burugle som deg. ",
            "Du er så stygg og jeg vil aldri se deg igjen. ",
            };

        public List<string> Filler = new List<string>() {
            "Jeg håper du får en flott fest til helgen :) ",
            "Håper den derre greia du skal på til det tidspunktet blir ok+. ",
            };

        public List<string> Ending = new List<string>() {
            "veldig glad for at jeg har fått bli kjent med deg.",
            "Sees aldri!",
            };
        

        //Default Response      Ground Zero
        public string GetDefaultResponse()
        {
            return Intro[0] + GoodResponse[0] + Filler[0] + Ending[0];
        }

        public string GetRandomResponse()
        {
            Random ran = new Random();
            var GoodOrBad = ran.Next(3);
            string MeanessResponse = "";
            switch (GoodOrBad)
            {
                case 0:
                    MeanessResponse = GoodResponse[ran.Next(GoodResponse.Count)];
                    break;

                case 1:
                    MeanessResponse = NormalReponse[ran.Next(NormalReponse.Count)];
                    break;

                case 2:
                    MeanessResponse = BadResponse[ran.Next(BadResponse.Count)];
                    break;
            }

            return Intro[ran.Next(Intro.Count)] + MeanessResponse + Filler[ran.Next(Filler.Count)] + Ending[ran.Next(Ending.Count)];
        }



    }
}
