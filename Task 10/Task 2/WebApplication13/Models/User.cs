﻿using System;
using System.Collections.Generic;

namespace WebApplication13.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public byte[]? PasswordHash { get; set; }

    public string? Password { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
