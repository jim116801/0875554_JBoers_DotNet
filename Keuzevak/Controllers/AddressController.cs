using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Keuzevak.Models;
using Microsoft.Ajax.Utilities;

namespace Keuzevak.Controllers
{
    public class AddressController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Address
        public ActionResult Index(string address, string sortOrder, string currentFilter, string searchString)
        {
            var AddressList = new List<string>();

            var AddressQry = from d in db.Adres
                orderby d.Address
                select d.Address;

            AddressList.AddRange(AddressQry.Distinct());
            ViewBag.address = new SelectList(AddressList);

            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.LongitudeSortParm = sortOrder == "Longitude" ? "longitude_desc" : "Longitude";
            ViewBag.LatitudeSortParm = sortOrder == "Latitude" ? "latitude_desc" : "Latitude";

            ViewBag.CurrentFilter = searchString;

            var addresses = from s in db.Adres
                           select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                addresses = addresses.Where(s => s.Address.Contains(searchString));
                                       
            }

            if (!String.IsNullOrEmpty(address))
            {
                addresses = addresses.Where(s => s.Address == address);

            }

            switch (sortOrder)
            {
                case "address_desc":
                    addresses = addresses.OrderByDescending(s => s.Address);
                    break;
                case "Date":
                    addresses = addresses.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    addresses = addresses.OrderByDescending(s => s.Date);
                    break;
                case "Longitude":
                    addresses = addresses.OrderBy(s => s.Longitude);
                    break;
                case "longitude_desc":
                    addresses = addresses.OrderByDescending(s => s.Longitude);
                    break;
                case "Latitude":
                    addresses = addresses.OrderBy(s => s.Latitude);
                    break;
                case "latitude_desc":
                    addresses = addresses.OrderByDescending(s => s.Latitude);
                    break;
                default:
                    addresses = addresses.OrderBy(s => s.Address);
                    break;
            }

            return View(addresses);
        }
    }
}