using System;
using System.Collections.Generic;

namespace WebApplication13.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
