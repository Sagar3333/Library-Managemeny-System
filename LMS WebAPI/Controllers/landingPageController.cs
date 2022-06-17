using LMS_WebAPI.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS_WebAPI.Controllers
{
    public class landingPageController : ApiController
    {
        [Route("api/LandingPage")]
        [HttpGet]
        public Dictionary<string, List<topBooks>> GetLandingPage()
        {
            var GenreList = new List<string> { "%[a-z]%", "Novel", "Southern Gothic fiction", "education", "Fantasy" };
            var topBooksForEachGenreDict = new Dictionary<string, List<topBooks>>();
            var numberOfBooksToShow = 6;
            foreach (var Genre in GenreList)
            {
                //getting all Top books
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommandWrapper = db.GetSqlStringCommand("select top " + numberOfBooksToShow + " bookMaster.bookTitle, bookMaster.genre, readersReview.rating from readersReview inner join bookMaster on readersReview.bookMasterId = bookMaster.id where bookMaster.genre LIKE '" + Genre + "' ORDER BY rating DESC;");
                var ds = db.ExecuteDataSet(dbCommandWrapper);
                List<topBooks> topBooks = new List<topBooks>();

                for (var i = 0; i < ds.Tables[0].Rows.Count; i++) //iterating over whole table
                {
                    topBooks.Add(new topBooks // list of all books with high rating
                    {
                        rating = Convert.ToDecimal(ds.Tables[0].Rows[i]["rating"]),
                        bookTitle = Convert.ToString(ds.Tables[0].Rows[i]["bookTitle"])
                    });
                };
                topBooksForEachGenreDict[Genre] = topBooks;
            }
            return topBooksForEachGenreDict;
        }
    }
}
