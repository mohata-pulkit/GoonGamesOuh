using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoonGamesOuh.Models
{
    public class play
    {
        public int Id { get; set; }
        public string[] Prompt { get; set; }
        public string Answer { get; set; }
        public string ConfirmationMessage { get; set; }
    }
}
