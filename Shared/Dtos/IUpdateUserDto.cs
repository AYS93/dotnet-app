﻿namespace Shared.Dtos
{
    public interface IUpdateUserDto
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }
}
