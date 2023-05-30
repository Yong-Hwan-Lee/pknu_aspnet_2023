using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aspnet02_boardapp.Models
{
    public class Board
    {
        [Key] //PK
        public int Id { get; set; }


         // Not Null
        [Required(ErrorMessage ="아이디를 입력하세요")]
        [DisplayName("아이디")]
        
        public string UserId { get; set; }
        [DisplayName("이름")]
        public string? UserName { get; set; }   // Null 허용

        [Required(ErrorMessage = "제목을 입력하세요")]
        [MaxLength(200)] // ==Varchar(200)
        [DisplayName("제목")]
        public string Title { get; set; }
        [DisplayName("조회")]
        public int ReadCount { get; set; }
        [DisplayName("작성일")]
        public DateTime PostDate { get; set; }
        [DisplayName("게시글")]
        public string Contents { get; set; }

    }
    
}
