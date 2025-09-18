namespace Files
{

    public class Movie
    {
        public string Film { get; }
        public string Genre { get; }
        public string LeadStudio { get; }
        public string AudienceScore { get; }
        public string Profitability { get; }
        public string RottenTomatoes { get; }
        public string WorldwideGross { get; }
        public string Year { get; }

        public Movie(string film, string genre, string leadStudio, string audienceScore, string profitability, string rottenTomatoes, string worldwideGross, string year)
        {
            Film = film;
            Genre = genre;
            LeadStudio = leadStudio;
            AudienceScore = audienceScore;
            Profitability = profitability;
            RottenTomatoes = rottenTomatoes;
            WorldwideGross = worldwideGross;
            Year = year;
        }

        public override string ToString()
        {
            return $"Film: {Film}, Genre: {Genre}, Lead Studio: {LeadStudio}, " +
                   $"Audience Score: {AudienceScore}, Profitability: {Profitability}, " +
                   $"Rotten Tomatoes: {RottenTomatoes}, Worldwide Gross: {WorldwideGross}, Year: {Year}";
        }
    }
}