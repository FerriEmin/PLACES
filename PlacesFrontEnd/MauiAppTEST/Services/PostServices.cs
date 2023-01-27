using MauiAppTEST.Models;

namespace MauiAppTEST.Services
{
    public class PostServices
    {
        public static void LoadPosts()
        {
            List<Post> Posts = new List<Post>()
            {
                new Post(){ Name="Bicycle Marathon", Details="Kom hit och cykla, njut av solen och det fina vädret hihi", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=5, Comment="WOW SÅ COOLT"} } },
                new Post(){ Name="Vladimir Putin Fanclub", Details="Ogon po' govnasti, idi nahoi blyat", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=2, Comment="for real asså?" } } },
                new Post(){ Name="Dog meeting", Details="Golden retrievers gather! hehe", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=3, Comment="Fattigt ställe for rael mannen"} } },
                new Post(){ Name="Psychopath meetup", Details="Come and feet some fellow psychopaths", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=3, Comment="SÅ MÅNGA PSYCHOPATHS"} } },
                new Post(){ Name="Rammstein", Details="Alla rockhuven se hit, KOM HIT och nicka era huven fram och tillbaka som om ni sög den osynliga kuken!", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=1, Comment="BAJsmannen"} } },
                new Post(){ Name="Neo Nazi meet up", Details="Wenn die arische Rasse weiterleben soll, müssen wir in Stockholm Wohnraum für die Arbeiterklasse schaffen", Country = new Country() { Name="paris" }, Reviews = new List <Review> { new Review() { Rating = 2, Comment = "så fattigt ställe" } }},
            };
        }

        public static List<Post> GetPosts()
        {
            List<Post> Posts = new List<Post>()
            {
                new Post(){ Name="Bicycle Marathon", Details="Kom hit och cykla, njut av solen och det fina vädret hihi", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=5, Comment="WOW SÅ COOLT"} } },
                new Post(){ Name="Vladimir Putin Fanclub", Details="Ogon po' govnasti, idi nahoi blyat", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=2, Comment="for real asså?" } } },
                new Post(){ Name="Dog meeting", Details="Golden retrievers gather! hehe", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=3, Comment="Fattigt ställe for rael mannen"} } },
                new Post(){ Name="Psychopath meetup", Details="Come and feet some fellow psychopaths", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=3, Comment="SÅ MÅNGA PSYCHOPATHS"} } },
                new Post(){ Name="Rammstein", Details="Alla rockhuven se hit, KOM HIT och nicka era huven fram och tillbaka som om ni sög den osynliga kuken!", Country = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=1, Comment="BAJsmannen"} } },
                new Post(){ Name="Neo Nazi meet up", Details="Wenn die arische Rasse weiterleben soll, müssen wir in Stockholm Wohnraum für die Arbeiterklasse schaffen", Country = new Country() { Name="paris" }, Reviews = new List <Review> { new Review() { Rating = 2, Comment = "så fattigt ställe" } }},
            };

            return Posts;
        }

    }
}
