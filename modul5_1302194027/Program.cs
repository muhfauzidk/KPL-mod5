using System;
using System.Diagnostics.Contracts;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        //Generate 5 digit random number
        Random r = new Random();
        this.id = r.Next(100000);
        string fiveDigit = this.id.ToString("D5");

        //DbC preconditions
        Contract.Requires(title != null && title.Length <= 200);

        playCount = 0;
        this.title = title;
    }

    public void IncreasePlayCount(int playcount)
    {
        //DbC preconditions
        Contract.Requires(playcount > 0 && playcount <= 25000000);

        //Exception
        try
        {
            checked
            {
                playcount += 1;
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
        }
        this.playCount = playcount;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("id: " + this.id);
        Console.WriteLine("title: " + this.title);
        Console.WriteLine("play count: " + this.playCount + "\n");
    }
}

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string Username)
    {
        //DbC preconditions
        Contract.Requires(Username != null && Username.Length <= 100);

        this.Username = Username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        return this.uploadedVideos.Count;
    }

    public void AddVideo(SayaTubeVideo x)
    {
        //DbC preconditions
        Contract.Requires(x != null);

        uploadedVideos.Add(x);
    }

    public void PrintAllVideoPlaycount()
    {
        int i = 1;

        //DbC postconditions
        Contract.Ensures(uploadedVideos.Count() <= 8);

        Console.WriteLine("User: " + this.Username);
        while (i < uploadedVideos.Count)
        {
            Console.WriteLine("Video " + i + " judul: " + this.uploadedVideos);
            i++;
        }
    }
}

public class Program
{
    public static void Main()
    {
        string judul1 = "The Godfather";
        string judul2 = "The Godfather 2";
        string username = "Uzi";
        //Create object of class SayaTubeVideo
        SayaTubeVideo f1 = new SayaTubeVideo(judul1);
        SayaTubeVideo f2 = new SayaTubeVideo(judul2);

        //Create object of class SayaTubeUser
        SayaTubeUser u = new SayaTubeUser(username);

        f1.IncreasePlayCount(1);
        f1.PrintVideoDetails();
        u.AddVideo(f1);

        f2.IncreasePlayCount(2);
        f2.PrintVideoDetails();
        u.AddVideo(f2);

        u.GetTotalVideoPlayCount();
        u.PrintAllVideoPlaycount();
    }
}