using NAudio.Wave;
using Windows.Win32;
static class Program
{
    const uint ATTACH_PARENT_PROCESS = unchecked((uint)-1);
    const string Url1645 = "https://www.city.chofu.lg.jp/documents/221/wagamachichofu_1.mp3";
    static readonly string path1645 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wagamachichofu.mp3");
    static async Task Main()
    {
        await Check1645();
        WaveOutEvent waveOutEvent = new();
        AudioFileReader audioFileReader = new(path1645);
        waveOutEvent.PlaybackStopped += (_, _) => Environment.Exit(0);
        waveOutEvent.Init(audioFileReader);
        waveOutEvent.Play();
        await Task.Delay(int.MaxValue);
    }

    static async Task Check1645()
    {
        if (File.Exists(path1645))
        {
            return;
        }
        if (PInvoke.AttachConsole(ATTACH_PARENT_PROCESS))
        {
            Console.Clear();
        }
        Console.WriteLine($"\"{path1645}\" does not exist.\nDownloading from \"{Url1645}\" . . .");

        byte[] bytes1645;
        using (HttpClient httpClient = new())
        {
            bytes1645 = await httpClient.GetByteArrayAsync(Url1645);
        }
        using (FileStream file1645 = new(path1645, FileMode.CreateNew))
        {
            file1645.Write(bytes1645, 0, bytes1645.Length);
        }
        Console.WriteLine("Downloaded.");
    }
}