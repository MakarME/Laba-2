using System.Xml;

namespace Laba_2
{
    class DOM : Parse
    {
        public List<Dorm> Search(Stream stream)
        {
            List<Dorm> result = new List<Dorm>();
            XmlDocument document = new XmlDocument();
            document.Load(stream);
            XmlNode node = document.DocumentElement;
            foreach(XmlNode nod in node.ChildNodes)
            {
                string Name = "";
                string Faculty = "";
                string Course = "";
                string Residence = "";
                string Date = "";

                foreach(XmlAttribute attribute in nod.Attributes)
                {
                    if (attribute.Name.Equals("Name"))
                        Name = attribute.Value;
                    if (attribute.Name.Equals("Faculty"))
                        Faculty = attribute.Value;
                    if (attribute.Name.Equals("Course"))
                        Course = attribute.Value;
                    if (attribute.Name.Equals("Residence"))
                        Residence = attribute.Value;
                    if (attribute.Name.Equals("Date"))
                        Date = attribute.Value;
                }
                if(Name != "" && Faculty != "" && Course != "" && Residence != "" && Date != "")
                {
                    Dorm myDorm = new Dorm();
                    myDorm.Name = Name;
                    myDorm.Faculty = Faculty;
                    myDorm.Course = Course;
                    myDorm.Residence = Residence;
                    myDorm.Date = Date;
                    result.Add(myDorm);
                }
            }
            return result;
        }
    }
}