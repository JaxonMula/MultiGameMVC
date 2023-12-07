using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiGame.Models.PlayerModels;
public class PlayerIndex
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? FavoriteGame {get; set;} = string.Empty;
}
