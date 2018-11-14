using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp01_WebServices
{
    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }

        public string Message()
        {
            string ratings = "";

            foreach (Rating rating in Ratings)
            {
                ratings += Environment.NewLine + "\t" + "Source: " + rating.Source + 
                           Environment.NewLine + "\t" + "Value: " + rating.Value;
            }


            string x = "Title: " + Title + Environment.NewLine +
                       "Year: " + Year + Environment.NewLine +
                       "Rated: " + Rated + Environment.NewLine +
                       "Released: " + Released + Environment.NewLine +
                       "Runtime: " + Runtime + Environment.NewLine +
                       "Genre: " + Genre + Environment.NewLine +
                       "Director: " + Director + Environment.NewLine +
                       "Writer: " + Writer + Environment.NewLine +
                       "Actors: " + Actors + Environment.NewLine +
                       "Plot: " + Plot + Environment.NewLine +
                       "Language: " + Language + Environment.NewLine +
                       "Country: " + Country + Environment.NewLine +
                       "Awards: " + Awards + Environment.NewLine +
                       "Ratings: " + ratings + Environment.NewLine +
                       "Metascore: " + Metascore + Environment.NewLine +
                       "imdbRating: " + imdbRating + Environment.NewLine +
                       "imdbVotes: " + imdbVotes + Environment.NewLine +
                       "imdbID: " + imdbID + Environment.NewLine +
                       "Type: " + Type + Environment.NewLine +
                       "DVD: " + DVD + Environment.NewLine +
                       "BoxOffice: " + BoxOffice + Environment.NewLine +
                       "Production: " + Production + Environment.NewLine;
            return x;
        }
    }
}
