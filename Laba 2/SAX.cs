using System.Xml;

namespace Laba_2
{
    class SAX : Parse
    {
        public List<Dorm> Search(Stream stream)
        {
            List<Dorm> result = new List<Dorm>();
            var xmlReader = new XmlTextReader(stream);
            while(xmlReader.Read())
            {
                if(xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        string Name = "";
                        string Faculty = "";
                        string Course = "";
                        string Residence = "";
                        string Date = "";

                        if(xmlReader.Name.Equals("Name"))
                        {
                            Name = xmlReader.Value;
                            xmlReader.MoveToNextAttribute();

                            if (xmlReader.Name.Equals("Faculty"))
                            {
                                Faculty = xmlReader.Value;
                                xmlReader.MoveToNextAttribute();

                                if (xmlReader.Name.Equals("Course"))
                                {
                                    Course = xmlReader.Value;
                                    xmlReader.MoveToNextAttribute();

                                    if (xmlReader.Name.Equals("Residence"))
                                    {
                                        Residence = xmlReader.Value;
                                        xmlReader.MoveToNextAttribute();

                                        if (xmlReader.Name.Equals("Date"))
                                        {
                                            Date = xmlReader.Value;
                                        }
                                    }
                                }
                            }
                        }
                        if (Name != "" && Faculty != "" && Course != "" && Residence != "" && Date != "")
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
                    
                }
            }

            return result;
        }
    }
}