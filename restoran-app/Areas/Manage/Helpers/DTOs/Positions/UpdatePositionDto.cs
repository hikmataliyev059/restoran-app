﻿namespace restoran_app.Areas.Manage.Helpers.DTOs.Positions;

public record UpdatePositionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
