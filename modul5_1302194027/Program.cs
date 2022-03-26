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

        playCount = 0;
        this.title = title;
    }

    public void IncreasePlayCount(int jmlAngka)
    {
        this.playCount = jmlAngka;
        jmlAngka += 1;
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
        this.Username = Username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        return this.uploadedVideos.Count;
    }

    public void AddVideo(SayaTubeVideo x)
    {
        uploadedVideos.Add(x);

    }

    public void PrintAllVideoPlaycount()
    {
        int i = 1;

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