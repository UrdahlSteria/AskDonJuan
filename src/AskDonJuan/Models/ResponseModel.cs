using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AskDonJuan.Models
{
    public class ResponseModel
    {

        [Key]
        public int ResponseKey { get; set; }

        public string TheResponse { get; set; }
        public HowTo confrontationType { get; set; }


        public enum HowTo
        {
            [Display (Name = "Send an SMS. ")]
            msg,
            [Display (Name = "This you have to take face-to-face. ")]
            faceToFace,
            [Display (Name ="Maybe have a proper talk? ")]
            properTalk,
        };

        // Innser at disse introduksjoene fungrerer i veldig forskjellige situasjoner
        public List<string> Intro = new List<string>() {
            "Du, jeg har tenkt litt ",
            "Hei, hør her... ",
            "Vi må snakke sammen... Eller, jeg har noe jeg vil si. ",
            "Jeg har noe jeg trenger å få at hjertet. ",
            "Jeg vil ikke såre deg, men, " };

        public List<string> KindResponse = new List<string>() {
            "Du er en utrolig kul jente som det har vært kjempegøy å være sammen med, men kjenner at det ikke føler helt riktig. Tenkte kanskje at det var greit å si ifra, før enn senere. ",
            "Vi har hatt det veldig gøy sammen i det siste, men tror ikke dette går noen steder, om du skjønner? ",
            "Jeg har lyst til å møte deg mer, men kjenner at jeg må rydde opp i noen greier i livet mitt først, så tror ikke vi kan treffes lengre. ",
             };

        public List<string> NormalResponse = new List<string>() {
            "Vi har hatt det gøy sammen, men jeg har ikke tid til det lengre. Jeg må gjøre andre ting. ",
            "Du har vært topp, men dette går ingen steder. ",
            };

        public List<string> BadResponse = new List<string>() {
            "Jeg skjønner ikke hva jeg tenkte da jeg hooket opp med en burugle som deg. ",
            "Du er så stygg og jeg vil aldri se deg igjen. ",
            "Du vet \"Stygge Lille Trine\" egentlig handler om deg? Så tror ikke jeg er keen på å se deg igjen as. "
            };

        public List<string> Filler = new List<string>() {
            "Jeg håper du får en flott fest til helgen :) ",
            "Håper den derre greia du skal på til det tidspunktet blir ok+. ",
            "Du får ha lykke til videre. ",
            "You do you. "
            };

        public List<string> Ending = new List<string>() {
            "veldig glad for at jeg har fått bli kjent med deg.",
            "Sees aldri!",
            "Sees kanskje rundt?",
            "Håper vi kan være venner."
            };

        public string ProperTalk = "Om man har vært sammen så lenge som dere har, er det kanskje greit å ta en ordentlig prat? Her kan det være lurt å dele føleleser og fortelle sannheten. " + 
            "MEN! Om du vet du vil komme deg ut av det, si: \"Jeg er veldig glad i deg, men jeg elsker deg ikke lengre...\"";
            
            //"When you have been together for so long, Don Juan recommends to have a proper talk. Share ones emotions and feelings and telling the truth is probably a good idea. " +
            //"If you absolutly want to break up, and don't want to share a why. Say the following: \"\"";


        

        //public ResponseModel PreDraftGetResponse(QueryModel.MeanessEnum meaness, bool inRelationship, QueryModel.DurationEnum durationType, int durationLength )
        //{
        //    string Meanessresponse = "";
        //    HowTo BreakType = HowTo.faceToFace;

        //    Random ran = new Random();

        //    //Categorize
        //    if ((durationType == QueryModel.DurationEnum.Weeks_Dating && durationLength < 7)|| (durationType == QueryModel.DurationEnum.Number_of_Dates && durationLength < 7))
        //    {
        //        BreakType = HowTo.msg;
        //    }
        //    else if (durationType == QueryModel.DurationEnum.Years_Together && durationLength > 3)
        //    {
        //        BreakType = HowTo.properTalk;
        //        return new ResponseModel { TheResponse = ProperTalk};
        //    }

        //    switch (meaness)
        //    {
        //        case QueryModel.MeanessEnum.Kind:
        //            Meanessresponse = KindResponse[ran.Next(NormalReponse.Count)];
        //            break;

        //        case QueryModel.MeanessEnum.Mean:
        //            Meanessresponse = BadResponse[ran.Next(NormalReponse.Count)];
        //            break;

        //        default:
        //            Meanessresponse = NormalReponse[ran.Next(NormalReponse.Count)];
        //            break;

        //    }

        //    //Build actual response
        //    string response = "";
        //    return new ResponseModel { TheResponse = response };


        //}

        //Default Response      Ground Zero
        public string GetDefaultResponse()
        {
            return Intro[0] + KindResponse[0] + Filler[0] + Ending[0];
        }

        public string GetRandomResponse()
        {
            Random ran = new Random();
            var GoodOrBad = ran.Next(3);
            string MeanessResponse = "";
            switch (GoodOrBad)
            {
                case 0:
                    MeanessResponse = KindResponse[ran.Next(KindResponse.Count)];
                    break;

                case 1:
                    MeanessResponse = NormalResponse[ran.Next(NormalResponse.Count)];
                    break;

                case 2:
                    MeanessResponse = BadResponse[ran.Next(BadResponse.Count)];
                    break;
            }

            return Intro[ran.Next(Intro.Count)] + MeanessResponse + Filler[ran.Next(Filler.Count)] + Ending[ran.Next(Ending.Count)];
        }



    }
}
