using Microsoft.Maui.Controls;
using Microsoft.Win32;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Security.Policy;
using System.Xml.Linq;
using System.Collections.ObjectModel;


namespace Laba_2
{
    class Dorm
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Course { get; set; }
        public string Residence{ get; set; }
        public string Date { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            ObservableCollection<string> namesList = new ObservableCollection<string>();
            ObservableCollection<string> facultiesList = new ObservableCollection<string>();
            ObservableCollection<string> coursesList = new ObservableCollection<string>();
            ObservableCollection<string> residencesList = new ObservableCollection<string>();
            ObservableCollection<string> datesList = new ObservableCollection<string>();
            Stream table = null;
            InitializeComponent();

            this.Title = "Makar K27";

            CheckBox checkBox1 = new CheckBox
            {
                VerticalOptions = LayoutOptions.Center
            };

            Picker picker1 = new Picker
            {
                Title = "Name",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = checkBox1.IsChecked
            };

            picker1.ItemsSource = namesList;

            checkBox1.CheckedChanged += (sender, args) =>
            {
                picker1.IsEnabled = checkBox1.IsChecked;
            };

            CheckBox checkBox2 = new CheckBox
            {
                VerticalOptions = LayoutOptions.Center
            };

            Picker picker2 = new Picker
            {
                Title = "Faculty",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = checkBox2.IsChecked
            };

            picker2.ItemsSource = facultiesList;

            checkBox2.CheckedChanged += (sender, args) =>
            {
                picker2.IsEnabled = checkBox2.IsChecked;
            };

            CheckBox checkBox3 = new CheckBox
            {
                VerticalOptions = LayoutOptions.Center
            };

            Picker picker3 = new Picker
            {
                Title = "Course",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = checkBox3.IsChecked
            };

            picker3.ItemsSource = coursesList;

            checkBox3.CheckedChanged += (sender, args) =>
            {
                picker3.IsEnabled = checkBox3.IsChecked;
            };

            CheckBox checkBox4 = new CheckBox
            {
                VerticalOptions = LayoutOptions.Center
            };

            Picker picker4 = new Picker
            {
                Title = "Residence",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = checkBox4.IsChecked
            };

            picker4.ItemsSource = residencesList;

            checkBox4.CheckedChanged += (sender, args) =>
            {
                picker4.IsEnabled = checkBox4.IsChecked;
            };

            CheckBox checkBox5 = new CheckBox
            {
                VerticalOptions = LayoutOptions.Center
            };

            Picker picker5 = new Picker
            {
                Title = "Date",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = checkBox5.IsChecked
            };

            picker5.ItemsSource = datesList;

            checkBox5.CheckedChanged += (sender, args) =>
            {
                picker5.IsEnabled = checkBox5.IsChecked;
            };

            RadioButton radioButton1 = new RadioButton { Content = "DOM", VerticalOptions = LayoutOptions.Center };
            RadioButton radioButton2 = new RadioButton { Content = "SAX", VerticalOptions = LayoutOptions.Center };
            RadioButton radioButton3 = new RadioButton { Content = "LINQ to XML", VerticalOptions = LayoutOptions.Center };

            Button searchButton = new Button { Text = "Search", VerticalOptions = LayoutOptions.Center };
            Button transformButton = new Button { Text = "Transform", VerticalOptions = LayoutOptions.Center };
            Button clearButton = new Button { Text = "Clear", VerticalOptions = LayoutOptions.Center };
            Button importButton = new Button { Text = "Import", VerticalOptions = LayoutOptions.Center };

            searchButton.IsEnabled = false;
            transformButton.IsEnabled = false;
            clearButton.IsEnabled = false;

            ListView dormListView = new ListView
            {
                RowHeight = 100,
                ItemsSource = new List<Dorm> { new Dorm { }, new Dorm { }, new Dorm { } },
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    grid.Children.Add(nameLabel);

                    var facultyLabel = new Label();
                    facultyLabel.SetBinding(Label.TextProperty, "Faculty");
                    Grid.SetColumn(facultyLabel, 1);
                    grid.Children.Add(facultyLabel);

                    var courseLabel = new Label();
                    courseLabel.SetBinding(Label.TextProperty, "Course");
                    Grid.SetColumn(courseLabel, 2);
                    grid.Children.Add(courseLabel);

                    var residenceLabel = new Label();
                    residenceLabel.SetBinding(Label.TextProperty, "Residence");
                    Grid.SetColumn(residenceLabel, 3);
                    grid.Children.Add(residenceLabel);

                    var dateLabel = new Label();
                    dateLabel.SetBinding(Label.TextProperty, "Date");
                    Grid.SetColumn(dateLabel, 4);
                    grid.Children.Add(dateLabel);

                    return new ViewCell { View = grid };
                })
            };

            Content = new StackLayout
            {
                Children = {
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { checkBox1, picker1 } },
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { checkBox2, picker2 } },
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { checkBox3, picker3 } },
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { checkBox4, picker4 } },
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { checkBox5, picker5 } },
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { radioButton1, radioButton2, radioButton3 } },
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { searchButton, transformButton, clearButton, importButton } },
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { dormListView } }
                }
            };

            transformButton.Clicked += OnTransformButtonClicked;

            async void OnTransformButtonClicked(object sender, EventArgs e)
            {
                try
                {
                    if (table != null)
                    {
                        table.Seek(0, SeekOrigin.Begin);

                        XDocument xmlDoc;
                        xmlDoc = XDocument.Load(table);
                        table.Seek(0, SeekOrigin.Begin);

                        StringBuilder htmlBuilder = new StringBuilder();
                        htmlBuilder.AppendLine("<!DOCTYPE html>");
                        htmlBuilder.AppendLine("<html>");
                        htmlBuilder.AppendLine("<head>");
                        htmlBuilder.AppendLine("<title>Students Table</title>");
                        htmlBuilder.AppendLine("</head>");
                        htmlBuilder.AppendLine("<body>");
                        htmlBuilder.AppendLine("<table border='1'>");
                        htmlBuilder.AppendLine("<tr>");
                        htmlBuilder.AppendLine("<th>Name</th>");
                        htmlBuilder.AppendLine("<th>Faculty</th>");
                        htmlBuilder.AppendLine("<th>Course</th>");
                        htmlBuilder.AppendLine("<th>Residence</th>");
                        htmlBuilder.AppendLine("<th>Date</th>");
                        htmlBuilder.AppendLine("</tr>");

                        foreach (var student in xmlDoc.Descendants("student"))
                        {
                            string name = student.Attribute("Name")?.Value ?? "";
                            string faculty = student.Attribute("Faculty")?.Value ?? "";
                            string course = student.Attribute("Course")?.Value ?? "";
                            string residence = student.Attribute("Residence")?.Value ?? "";
                            string date = student.Attribute("Date")?.Value ?? "";

                            htmlBuilder.AppendLine("<tr>");
                            htmlBuilder.AppendLine($"<td>{name}</td>");
                            htmlBuilder.AppendLine($"<td>{faculty}</td>");
                            htmlBuilder.AppendLine($"<td>{course}</td>");
                            htmlBuilder.AppendLine($"<td>{residence}</td>");
                            htmlBuilder.AppendLine($"<td>{date}</td>");
                            htmlBuilder.AppendLine("</tr>");
                        }

                        htmlBuilder.AppendLine("</table>");
                        htmlBuilder.AppendLine("</body>");
                        htmlBuilder.AppendLine("</html>");

                        string htmlTable = htmlBuilder.ToString();

                        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string filePath = Path.Combine(currentDirectory, "students_table.html");

                        File.WriteAllText(filePath, htmlTable);
                        await DisplayAlert("Success", "Successfully converted." + "\n" + "Path to the file: " + currentDirectory + "students_table.html", "OK");
                        table.Seek(0, SeekOrigin.Begin);
                    }
                    else
                    {
                    }
                }
                catch (Exception)
                {
                }
            }


            clearButton.Clicked += OnClearButtonClicked;

            async void OnClearButtonClicked(object sender, EventArgs e)
            {
                dormListView.ItemsSource = new List<Dorm> { new Dorm { }, new Dorm { }, new Dorm { } };
            }
          

            importButton.Clicked += OnImportButtonClicked;

            async void OnImportButtonClicked(object sender, EventArgs e)
            {
                try
                {
                    var customFileType = new FilePickerFileType(
                        new Dictionary<DevicePlatform, IEnumerable<string>>
                        {
                { DevicePlatform.WinUI, new[] { ".xml"} }
                        });

                    var result = await FilePicker.Default.PickAsync(new PickOptions
                    {
                        PickerTitle = "Pick xml",
                        FileTypes = customFileType
                    });

                    if (result != null)
                    {
                        if (result.FileName.EndsWith("xml", StringComparison.OrdinalIgnoreCase))
                        {
                            table = await result.OpenReadAsync();

                            if (radioButton1.IsChecked)
                            {
                                DOM b = new DOM();
                                var dormList = b.Search(table);
                                dormListView.ItemsSource = dormList;
                            }
                            if (radioButton2.IsChecked)
                            {
                                SAX b = new SAX();
                                var dormList = b.Search(table);
                                dormListView.ItemsSource = dormList;
                            }
                            if (radioButton3.IsChecked)
                            {
                                LINQ b = new LINQ();
                                var dormList = b.Search(table);
                                dormListView.ItemsSource = dormList;
                            }
                            searchButton.IsEnabled = true;
                            transformButton.IsEnabled = true;
                            clearButton.IsEnabled = true;
                            try
                            {
                                table.Seek(0, SeekOrigin.Begin);
                                XDocument xmlDoc = XDocument.Load(table);
                                namesList.Clear();
                                facultiesList.Clear();
                                coursesList.Clear();
                                residencesList.Clear();
                                datesList.Clear();

                                foreach (var student in xmlDoc.Descendants("student"))
                                {
                                    string name = student.Attribute("Name")?.Value ?? "";
                                    string faculty = student.Attribute("Faculty")?.Value ?? "";
                                    string course = student.Attribute("Course")?.Value ?? "";
                                    string residence = student.Attribute("Residence")?.Value ?? "";
                                    string date = student.Attribute("Date")?.Value ?? "";

                                    if (!namesList.Contains(name))
                                        namesList.Add(name);

                                    if (!facultiesList.Contains(faculty))
                                        facultiesList.Add(faculty);

                                    if (!coursesList.Contains(course))
                                        coursesList.Add(course);

                                    if (!residencesList.Contains(residence))
                                        residencesList.Add(residence);

                                    if (!datesList.Contains(date))
                                        datesList.Add(date);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            searchButton.Clicked += OnSearchButtonClicked;

            async void OnSearchButtonClicked(object sender, EventArgs e)
            {
                try
                {
                    table.Seek(0, SeekOrigin.Begin);
                    List<Dorm> filteredDormList = new List<Dorm>();

                    if (radioButton1.IsChecked)
                    {
                        DOM b = new DOM();
                        filteredDormList = b.Search(table);
                    }
                    else if (radioButton2.IsChecked)
                    {
                        SAX b = new SAX();
                        filteredDormList = b.Search(table);
                    }
                    else if (radioButton3.IsChecked)
                    {
                        LINQ b = new LINQ();
                        filteredDormList = b.Search(table);
                    }

                    if (picker1.SelectedItem != null && checkBox1.IsChecked)
                    {
                        string selectedName = picker1.SelectedItem.ToString();
                        filteredDormList = filteredDormList.Where(item => item.Name == selectedName).ToList();
                    }

                    if (picker2.SelectedItem != null && checkBox2.IsChecked)
                    {
                        string selectedFaculty = picker2.SelectedItem.ToString();
                        filteredDormList = filteredDormList.Where(item => item.Faculty == selectedFaculty).ToList();
                    }

                    if (picker3.SelectedItem != null && checkBox3.IsChecked)
                    {
                        string selectedCourse = picker3.SelectedItem.ToString();
                        filteredDormList = filteredDormList.Where(item => item.Course == selectedCourse).ToList();
                    }

                    if (picker4.SelectedItem != null && checkBox4.IsChecked)
                    {
                        string selectedResidence = picker4.SelectedItem.ToString();
                        filteredDormList = filteredDormList.Where(item => item.Residence == selectedResidence).ToList();
                    }

                    if (picker5.SelectedItem != null && checkBox5.IsChecked)
                    {
                        string selectedDate = picker5.SelectedItem.ToString();
                        filteredDormList = filteredDormList.Where(item => item.Date == selectedDate).ToList();
                    }

                dormListView.ItemsSource = filteredDormList;
                }
                catch (Exception)
                {
                }
            }

        }
    }
}