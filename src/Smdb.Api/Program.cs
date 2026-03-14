namespace Smdb.Api;

public class Program
{
    public static async Task Main()
    {
        App app = new App();
        await app.Start();

        ActorsApp actorsApp= new ActorsApp();
        await actorsApp.Start();
    }
}