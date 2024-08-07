using Microsoft.Extensions.Options;

namespace Movies.Api.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string JwtSectionName = "Jwt";
    
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(JwtSectionName).Bind(options);
    }
}