﻿using MagicTwins.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace MagicTwins.Auth.Model;

public interface IJwtProvider
{
    JwtToken Create(User user);
}