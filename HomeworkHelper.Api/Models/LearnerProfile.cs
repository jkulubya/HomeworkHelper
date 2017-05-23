using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkHelper.Api.Models
{
    public class LearnerProfile
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public List<Question> QuestionsAsked { get; set; }
    }
}
