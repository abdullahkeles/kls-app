using System;

namespace Identity.BLL.Auth.Post;

public record RefreshTokenRequest(Guid refreshToken);
