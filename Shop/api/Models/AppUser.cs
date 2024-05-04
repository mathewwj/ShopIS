﻿using Microsoft.AspNetCore.Identity;

namespace api.Models;

public class AppUser : IdentityUser
{
    public List<ShoppingList> ShoppingLists { get; set; } = new();
}