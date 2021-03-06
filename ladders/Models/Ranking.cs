﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ladders.Models
{
    public class Ranking
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual ProfileModel User { get; set; }

        [Required]
        public virtual int Wins { get; set; }

        [Required]
        public virtual int Losses { get; set; }

        [Required]
        public virtual int Draws { get; set; }

        [Required]
        public virtual int Position { get; set; }

        public virtual int? LadderModelId { get; set; }
        
        [Required]
        public virtual LadderModel LadderModel { get; set; }

        public virtual ICollection<Challenge> Challenges { get; set; }
    }
}
