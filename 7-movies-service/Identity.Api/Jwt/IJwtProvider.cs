namespace Identity.Api;

public interface IJwtProvider
{
    string Generate(TokenRegistrationRequest request);
}