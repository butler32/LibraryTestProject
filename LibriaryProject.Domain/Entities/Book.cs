namespace LibraryProject.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string ISBN { get; set; }
        public string Title { get; set; } 
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DateBack { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Book other = (Book)obj;
            return Id == other.Id &&
                   ISBN == other.ISBN &&
                   Title == other.Title &&
                   Genre == other.Genre &&
                   Description == other.Description &&
                   Author == other.Author &&
                   DateTaken == other.DateTaken &&
                   DateBack == other.DateBack;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ISBN, Title, Genre, Description, Author, DateTaken, DateBack);
        }
    }
}
