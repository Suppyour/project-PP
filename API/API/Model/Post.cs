namespace API;

public class Post
{
    public Post (Guid id, string user, int like)
    {
        Id = id;
        User = user;
        Like = like;
    }
    public string User { get; set; }
    public Guid Id { get; set; }
    public int Like { get; set; }
}
