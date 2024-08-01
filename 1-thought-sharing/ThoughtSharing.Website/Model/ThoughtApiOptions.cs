namespace ThoughtSharing.Website.Model;

public class ThoughtApiOptions
{
    private Uri? _baseUrl;

    public Uri BaseUrl
    {
        get => _baseUrl ?? throw new InvalidOperationException($"{nameof(BaseUrl)} is not set");
        set => _baseUrl = value;
    }
}