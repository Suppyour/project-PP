namespace API;

public class Post
{
    public Post (Guid id, User user, string text)
    {
        Id = id;
        User = user;
        Text = text;
    }
    public User User { get; set; }
    public string Text { get; set; }
    public Guid Id { get; set; }
}
