using System.Diagnostics;
using System.Threading.Tasks;

public static class ProcessExtensions
{
    public static Task WaitForExitAsync(this Process process)
    {
        var tcs = new TaskCompletionSource<object>();

        process.EnableRaisingEvents = true;
        process.Exited += (s, e) => tcs.TrySetResult(null);

        if (process.HasExited)
        {
            tcs.TrySetResult(null);
        }

        return tcs.Task;
    }
}

