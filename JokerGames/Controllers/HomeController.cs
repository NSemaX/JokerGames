using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JokerGames.Models;
using DomainService;
using Contract;
using Entities;
using Mapper;
using Newtonsoft.Json;

namespace JokerGames.Controllers
{
    public class HomeController : Controller
    {
        private IPlayerService _playerService;
        private ICardService _cardService;
        private IPurchaseService _purchaseService;

        public HomeController(IPlayerService playerService, ICardService cardService, IPurchaseService purchaseService)
        {
            this._playerService = playerService;
            this._cardService = cardService;
            this._purchaseService = purchaseService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Player()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Player(PlayerModel request)
        {
            Player player=request.ToEntity();
            _playerService.AddPlayer(player);

            ViewBag.Message = "Success.";

            return View();
        }


        public IActionResult Card()
        {
            CardModel model = new CardModel();

            List<DDLCategory> categories = new List<DDLCategory>();

            List<Player> playerlist = new List<Player>();
            playerlist = _playerService.GetPlayers();

            if (playerlist != null && playerlist.Count > 0)
                foreach (var item in playerlist)
                {
                    categories.Add(new DDLCategory { ID = item.Id, CategoryName = item.Username });
                }

            model.Selected_PlayerId = 1;
            model.PlayerList = new List<DDLCategory>();
            model.PlayerList = categories;


            return View(model);
        }

        [HttpPost]
        public IActionResult Card(CardModel request)
        {
            CardModel model = new CardModel();

            List<DDLCategory> categories = new List<DDLCategory>();

           //categories.Add(new DDLCategory { ID = 0, CategoryName = "Player1" });

           List<Player> playerlist=new List<Player>();
           playerlist=_playerService.GetPlayers();

           if(playerlist!=null && playerlist.Count>0)
           foreach (var item in playerlist)
           {
               categories.Add(new DDLCategory{ ID = item.Id, CategoryName = item.Username });
           }

            model.PlayerList = new List<DDLCategory>();
            model.PlayerList = categories;

            model.Selected_PlayerId = request.Selected_PlayerId;

            Card card = request.ToEntity();
            card.Player = _playerService.GetPlayer(request.Selected_PlayerId);
            _cardService.AddCard(card);

            ViewBag.Message = "Success.";

            return View(model);
        }

        public IActionResult Purchase()
        {
            PurchaseModel model = new PurchaseModel();

            List<DDLCategory> categories1 = new List<DDLCategory>();
            List<DDLCategory> categories2 = new List<DDLCategory>();

            List<Player> playerlist = new List<Player>();
            playerlist = _playerService.GetPlayers();

            if (playerlist != null && playerlist.Count > 0)
                foreach (var item in playerlist)
                {
                    categories1.Add(new DDLCategory { ID = item.Id, CategoryName = item.Username });
                }


            List<Card> cardlist = new List<Card>();
            cardlist = _cardService.GetCardsByPlayerId(1);

            if (cardlist != null && cardlist.Count > 0)
                foreach (var item in cardlist)
                {
                    categories2.Add(new DDLCategory { ID = item.Id, CategoryName = item.Number });
                }


            model.PlayerList = new List<DDLCategory>();
            model.PlayerList = categories1;
            model.Selected_PlayerId = 1;

            model.CardList = new List<DDLCategory>();
            model.CardList = categories2;
            model.Selected_CardId = 1;


            return View(model);
        }


        [HttpPost]
        public IActionResult Purchase(PurchaseModel request)
        {
            PurchaseModel model = new PurchaseModel();

            List<DDLCategory> categories1 = new List<DDLCategory>();
            List<DDLCategory> categories2 = new List<DDLCategory>();

            List<Player> playerlist = new List<Player>();
            playerlist = _playerService.GetPlayers();

            if (playerlist != null && playerlist.Count > 0)
                foreach (var item in playerlist)
                {
                    categories1.Add(new DDLCategory { ID = item.Id, CategoryName = item.Username });
                }


            List<Card> cardlist = new List<Card>();
            cardlist = _cardService.GetCardsByPlayerId(1);

            if (cardlist != null && cardlist.Count > 0)
                foreach (var item in cardlist)
                {
                    categories2.Add(new DDLCategory { ID = item.Id, CategoryName = item.Number });
                }


            model.PlayerList = new List<DDLCategory>();
            model.PlayerList = categories1;
            model.Selected_PlayerId = 1;

            model.CardList = new List<DDLCategory>();
            model.CardList = categories2;
            model.Selected_CardId = 1;

            Purchase purchase = request.ToEntity();
            purchase.Player = _playerService.GetPlayer(request.Selected_PlayerId);
            purchase.Card = _cardService.GetCard(request.Selected_CardId);
            _purchaseService.AddPurchase(purchase);

            ViewBag.Message = "Success.";

            return View(model);
        }

        [HttpPost]
        public JsonResult GetCardNumbersByPlayerId(int id)
        {
             List<DDLCategory> categories2 = new List<DDLCategory>();
            List<Card> cardlist = new List<Card>();
            cardlist = _cardService.GetCardsByPlayerId(id);

            if (cardlist != null && cardlist.Count > 0)
                foreach (var item in cardlist)
                {
                    categories2.Add(new DDLCategory { ID = item.Id, CategoryName = item.Number });
                }

            var jsonConvertData = JsonConvert.SerializeObject(categories2);
            return new JsonResult(jsonConvertData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
