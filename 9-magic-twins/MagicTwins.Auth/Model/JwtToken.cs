namespace MagicTwins.Auth.Model;

public record JwtToken(string Token)
{
    public static implicit operator string(JwtToken token) => token.Token;

    public static implicit operator JwtToken(string token) => new JwtToken(token);
}