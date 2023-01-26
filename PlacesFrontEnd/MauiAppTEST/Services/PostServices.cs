using MauiAppTEST.Models;

namespace MauiAppTEST.Services
{
    public class PostServices
    {
        public static void GetPosts()
        {
            List<Post> Posts = new List<Post>()
            {
                new Post(){ Name="Bicycle Marathon", city = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=5, Comment="Kom hit och cykla, njut av solen och det fina vädret hihi"} } },
                new Post(){ Name="Vladimir Putin Fanclub", city = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=2, Comment="Ogon po' govnasti, idi nahoi blyat"} } },
                new Post(){ Name="Dog meeting", city = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=3, Comment="Golden retrievers gather! hehe"} } },
                new Post(){ Name="Psychopath meetup", city = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=3, Comment="Come and feet some fellow psychopaths"} } },
                new Post(){ Name="Rammstein", city = new Country() { Name="stockholm" }, Reviews = new List<Review> { new Review() {Rating=1, Comment="Alla rockhuven se hit, KOM HIT och nicka era huven fram och tillbaka som om ni sög den osynliga kuken!"} } },
                new Post(){ Name="Rammstein", city = new Country() { Name="paris" }, Reviews = new List <Review> { new Review() { Rating = 2, Comment = "Wenn die arische Rasse weiterleben soll, müssen wir in Stockholm Wohnraum für die Arbeiterklasse schaffen" } }},
            };
        }

    }
}
