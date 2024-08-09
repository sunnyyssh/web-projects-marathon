using Microsoft.Extensions.Options;

namespace MagicTwins.Left;

public sealed class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void Configure(JwtOptions options)
    {
        options.Issuer = _configuration.GetRequiredSection("JwtSettings:Issuer").Value!;
        options.Audience = _configuration.GetRequiredSection("JwtSettings:Audience").Value!;
        options.Key = _configuration.GetRequiredSection("JwtSettings:Key").Value!;
    }
}