using System.Xml.Linq;


namespace Laba_2
{
    class LINQ : Parse
    {
        public List<Dorm> Search(Stream stream)
        {
            List<Dorm> AllResult = new List<Dorm>();
            var doc = XDocument.Load(stream);
            var result = from obj in doc.Descendants("student")
                         select new
                         {
                             Name = (string)obj.Attribute("Name"),
                             Faculty = (string)obj.Attribute("Faculty"),
                             Course = (string)obj.Attribute("Course"),
                             Residence = (string)obj.Attribute("Residence"),
                             Date = (string)obj.Attribute("Date")
                         };
            foreach(var n in result)
            {
                Dorm myDorm = new Dorm();
                myDorm.Name = n.Name;
                myDorm.Faculty = n.Faculty;
                myDorm.Course = n.Course;
                myDorm.Residence = n.Residence;
                myDorm.Date = n.Date;
                AllResult.Add(myDorm);
            }

            return AllResult;
        }
    }
}