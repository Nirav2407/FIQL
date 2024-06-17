using System.ComponentModel.DataAnnotations;

namespace Shopping.API.Models
{
    public class QuestionResponseDto
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public string QuestionTypeName { get; set; }
      
        public string QuestionTypeCode { get; set; }
    }
}
