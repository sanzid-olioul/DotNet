using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Languages
    {
        Bangla,
        English,
        Spanish,
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public DateTime? PublishedAt { get; set; }
        public Languages PrimaryLanguage { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
    }
}
