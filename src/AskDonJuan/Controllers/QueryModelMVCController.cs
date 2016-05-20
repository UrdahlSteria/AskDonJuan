using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AskDonJuan.Models;
using System;
using static AskDonJuan.Models.ResponseModel;

namespace AskDonJuan.Controllers
{
    public class QueryModelMVCController : Controller
    {
        private ApplicationDbContext _context;

        public QueryModelMVCController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: QueryModelMVC
        public IActionResult Index()
        {
            return View();
        }
        
        
        // GET: QueryModelMVC
        public IActionResult Create()
        {
            return View();
        }

        // GET: This is not ok, don't date that young
        public IActionResult DeltPaaToPlussSyv()
        {
            return View();
        }

        // POST: QueryModelMVC/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {

                if (!DeltPaaToPlusSyv(queryModel.UserAge, queryModel.OtherAge))
                {
                    //Delt på 2 pluss 7 BREACH, burde aldri date i utgangspunktet
                    return RedirectToAction("DeltPaaToPlussSyv"); //Må implementers 
                }
                // This response is based on the Pre-Draft-Responsemodel-created 20.05.2016
                ResponseModel response = PreDraftGetResponse(queryModel.Meaness, queryModel.InRelationship, queryModel.DurationType, queryModel.DurationVariable);
                return View("Index", response);
            }
            return View(queryModel);
        }

        public ResponseModel PreDraftGetResponse(QueryModel.MeanessEnum meaness, bool inRelationship, QueryModel.DurationEnum durationType, int durationLength)
        {
            var respModel = new ResponseModel();
            string Meanessresponse = "";
            respModel.confrontationType = HowTo.faceToFace;

            Random ran = new Random();

            //Categorize
            if ((durationType == QueryModel.DurationEnum.Weeks_Dating && durationLength < 7) || (durationType == QueryModel.DurationEnum.Number_of_Dates && durationLength < 7))
            {
                respModel.confrontationType = HowTo.msg;
            }
            //Cutting short, for longterm relationship break up response.
            else if (durationType == QueryModel.DurationEnum.Years_Together && durationLength > 3)
            {
                respModel.confrontationType = HowTo.properTalk;
                respModel.TheResponse = respModel.ProperTalk;
                return respModel;
            }

            switch (meaness)
            {
                case QueryModel.MeanessEnum.Kind:
                    Meanessresponse = respModel.KindResponse[ran.Next(respModel.KindResponse.Count)];
                    break;

                case QueryModel.MeanessEnum.Mean:
                    Meanessresponse = respModel.BadResponse[ran.Next(respModel.BadResponse.Count)];
                    break;

                default:
                    Meanessresponse = respModel.NormalResponse[ran.Next(respModel.NormalResponse.Count)];
                    break;

            }

            //Build actual response
            //Intro
            respModel.TheResponse = respModel.Intro[ran.Next(respModel.Intro.Count)] + 
                //Main response (Meaness)
                Meanessresponse + 
                //Filler, can be removed
                respModel.Filler[ran.Next(respModel.Filler.Count)] + 
                //Ending (Can/should also be Meaness based)
                respModel.Ending[ran.Next(respModel.Ending.Count)];
            return respModel;

        }




        public bool DeltPaaToPlusSyv(int perone, int pertwo)
        {
            if (( perone ) > ((pertwo/2)+7) && (pertwo) > ((perone/2)+7))
            {
                return true;
            }
            return false;
        }



    }
}
