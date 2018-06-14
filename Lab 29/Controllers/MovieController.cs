using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab_29.Models;

namespace Lab_29.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public List<Movy> GetAllMovies()
        {
            MoviesDBEntities ORM = new MoviesDBEntities();

            return ORM.Movies.ToList();
        }
        [HttpGet]
        public List<Movy> GetAllMoviesInCategory(string Category)
        {
            MoviesDBEntities ORM = new MoviesDBEntities();

            return ORM.Movies.Where(c => c.Category.Contains(Category)).ToList();
        }
        [HttpGet]
        public Movy GetRandomMovie()
        {
            MoviesDBEntities ORM = new MoviesDBEntities();
            List<Movy> Movies = ORM.Movies.ToList();
            Random r = new Random();

            int result = r.Next(1, Movies.Count);
            return Movies[result];
        }
        [HttpGet]
        public Movy GetRandomMovieCategory(string Category)
        {
            MoviesDBEntities ORM = new MoviesDBEntities();
            List<Movy> Movies = ORM.Movies.Where(c => c.Category.Contains(Category)).ToList();

            Random r = new Random();

            int result = r.Next(1, Movies.Count);
            return Movies[result];
        }
        [HttpGet]
        public List<Movy> GetRandomMovies(int Quantity)
        {
            MoviesDBEntities ORM = new MoviesDBEntities();
            Random R = new Random();
            List<Movy> Movies = ORM.Movies.ToList();
            List<Movy> MovieList = new List<Movy>();
            for (int i = 0; i < Quantity; i++)
            {

                int result = R.Next(MovieList.Count());
                MovieList.Add(MovieList[result]);
                MovieList.RemoveAt(result);
            }

            //Random R = new Random();
            //int result = R.Next(1, Movies.Count);

            return Movies;
        }
        [HttpGet]
        public List<string> GetAllMovyCategory()
        {
            MoviesDBEntities ORM = new MoviesDBEntities();
            return ORM.Movies.Select(c => c.Category).Distinct().ToList();

        }
       

    }

}

