namespace Practice_9._2
{
    public class Holiday
    {
        protected string Name;
        protected DateTime Date;

        public Holiday(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }
        
        public string GetName()
        {
            return Name;
        }

        public DateTime GetDate()
        {
            return Date;
        }

        public void SetName(string newName)
        {
            Name = newName;
        }

        public void SetDate(DateTime newDate)
        {
            Date = newDate;
        }
        
        public bool IsWinter()
        {
            return Date.Month == 12 || Date.Month == 1 || Date.Month == 2;
        }
        
        public override string ToString()
        {
            return Name + " - " + Date.ToString("dd.MM.yyyy");
        }
    }
}