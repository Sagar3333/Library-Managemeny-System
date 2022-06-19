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
        public Dictionary<string, List<topBooks>> Index()
        {
            var GenreList = new List<string> { "%[a-z]%", "Novel", "Southern Gothic fiction", "education", "Fantasy" };
            var topBooksForEachGenreDict = new Dictionary<string, List<topBooks>>();
            var numberOfBooksToShow = 6;
            foreach (var Genre in GenreList)
            {
                //getting all Top books
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommandWrapper = db.GetSqlStringCommand("select top " + numberOfBooksToShow + " bookMaster.id, bookMaster.bookTitle, bookMaster.genre, readersReview.rating from readersReview inner join bookMaster on readersReview.bookMasterId = bookMaster.id where bookMaster.genre LIKE '" + Genre + "' ORDER BY rating DESC;");
                var ds = db.ExecuteDataSet(dbCommandWrapper);
                List<topBooks> topBooks = new List<topBooks>();

                for (var i = 0; i < ds.Tables[0].Rows.Count; i++) //iterating over whole table
                {
                    if (Genre == "%[a-z]%")
                    {
                        topBooks.Add(new topBooks // list of all books with high rating
                        {
                            id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"]),
                            rating = Convert.ToDecimal(ds.Tables[0].Rows[i]["rating"]),
                            bookTitle = Convert.ToString(ds.Tables[0].Rows[i]["bookTitle"]),
                            genre = Convert.ToString(ds.Tables[0].Rows[i]["genre"])
                        });
                    }
                    else
                    {
                        topBooks.Add(new topBooks // list of all books with high rating
                        {
                            id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"]),
                            rating = Convert.ToDecimal(ds.Tables[0].Rows[i]["rating"]),
                            bookTitle = Convert.ToString(ds.Tables[0].Rows[i]["bookTitle"])
                        });
                    }
                };
                topBooksForEachGenreDict[Genre] = topBooks;
            }
            return topBooksForEachGenreDict;
        }

        [Route("api/aboutBook/{id}")]
        [HttpGet]
        public topBooks aboutBook(int id)
        {
            //getting all Top books
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommandWrapper = db.GetSqlStringCommand("select bookMaster.id, bookMaster.bookTitle, bookMaster.publisher, bookMaster.writers, bookMaster.genre, readersReview.rating from readersReview inner join bookMaster on readersReview.bookMasterId = bookMaster.id where bookMaster.id = " + id);
            var ds = db.ExecuteDataSet(dbCommandWrapper);
            topBooks aboutBook = new topBooks();
            aboutBook.bookTitle = Convert.ToString(ds.Tables[0].Rows[0]["bookTitle"]);
            aboutBook.publisher = Convert.ToString(ds.Tables[0].Rows[0]["publisher"]);
            aboutBook.writers = Convert.ToString(ds.Tables[0].Rows[0]["writers"]);
            aboutBook.genre = Convert.ToString(ds.Tables[0].Rows[0]["genre"]);
            aboutBook.rating = Convert.ToDecimal(ds.Tables[0].Rows[0]["rating"]);
            return aboutBook;
        }
    }
}
