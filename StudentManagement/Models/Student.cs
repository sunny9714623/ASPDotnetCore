using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    /// <summary>
    /// 学生模型
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        [Display(Name ="班级")]
        [Required(ErrorMessage ="请输入名字"),MaxLength(50,ErrorMessage ="名字的长度不能超过50个字符") ]
        public string Name { get; set; }
        [Required]
        [Display(Name = "班级信息")]
        public ClassNameEnum? ClassName { get; set; }
        [Required]
        [Display(Name = "邮箱地址")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="邮箱的格式不正确")]
        public string Email { get; set; }
        public string Photo { get; set; }
        public int DeleteProperty { get; set; }
    }
}
