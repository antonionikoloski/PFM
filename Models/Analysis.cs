


namespace pfm.Models
{
    public class Analysis<T>
    {
        public string catcode {get; set;}
        public string startdate {get; set;}
        public string enddate {get; set;}

        public string direction {get;set;}

        public List<T> Items {get;set;}
    }
}