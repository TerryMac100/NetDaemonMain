namespace NetDaemonMain.apps.FoxEss.FoxApiClient.Models;

public interface IFoxRequest
{
    void Validate();

    string RequestUri { get; }

    bool GetRequest { get; }
}
