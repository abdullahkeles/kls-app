using System;

namespace Identity.BLL.Auth.Post;

public record AuthRequest(string userName, string password);
