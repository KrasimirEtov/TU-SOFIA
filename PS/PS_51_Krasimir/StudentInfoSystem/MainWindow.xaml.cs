﻿using StudentRepository;
using System.Linq;
using System.Windows;
using UserLogin;
using System.Linq;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClearData_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Find better way of doing this
            txtCourse.Text = "";
            txtDegree.Text = "";
            txtFaculty.Text = "";
            txtFacultyNumber.Text = "";
            txtFirstName.Text = "";
            txtGroup.Text = "";
            txtLastName.Text = "";
            txtSpecialty.Text = "";
            txtStatus.Text = "";
            txtStream.Text = "";
            txtSurName.Text = "";
        }

        private void BtnFillData_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Find better way of doing this. Also add input box to get the current student
            var repository = new StudentData();
            var student = repository.Students[0];

            txtCourse.Text = student.Course.ToString();
            txtDegree.Text = student.Degree;
            txtFaculty.Text = student.Faculty;
            txtFacultyNumber.Text = student.FacultyNumber;
            txtFirstName.Text = student.FirstName;
            txtGroup.Text = student.Group.ToString();
            txtLastName.Text = student.LastName;
            txtSpecialty.Text = student.Specialty;
            txtStatus.Text = student.Status;
            txtStream.Text = student.Stream.ToString();
            txtSurName.Text = student.SurName;
        }

        private void BtnDisableInputs_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Find better way of doing this
            DisableInputFields();


        }

        private void BtnEnableInputs_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Find better way of doing this
            EnableInputFields();

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var students = UserData.Users;
            var user = students.FirstOrDefault(x => x.UserName == txtInputUserName.Text && x.Password == txtInputPassword.Text);
            if (user == null)
            {
                txtInputPassword.Text = "";
                txtInputUserName.Text = "";
                DisableInputFields();
                MessageBox.Show($"Грешка! Няма такъв потребител.");
                return;
            }

            var studentRepo = new StudentData();
            var student = studentRepo.IsThereStudent(user.FacultyNumber);

            FillInputBoxesData(student);
            EnableInputFields();
            txtInputPassword.Text = "";
            txtInputUserName.Text = "";
        }

        private void EnableInputFields()
        {
            txtCourse.IsEnabled = true;
            txtDegree.IsEnabled = true;
            txtFaculty.IsEnabled = true;
            txtFacultyNumber.IsEnabled = true;
            txtFirstName.IsEnabled = true;
            txtGroup.IsEnabled = true;
            txtLastName.IsEnabled = true;
            txtSpecialty.IsEnabled = true;
            txtStatus.IsEnabled = true;
            txtStream.IsEnabled = true;
            txtSurName.IsEnabled = true;
        }

        private void DisableInputFields()
        {
            txtCourse.IsEnabled = false;
            txtDegree.IsEnabled = false;
            txtFaculty.IsEnabled = false;
            txtFacultyNumber.IsEnabled = false;
            txtFirstName.IsEnabled = false;
            txtGroup.IsEnabled = false;
            txtLastName.IsEnabled = false;
            txtSpecialty.IsEnabled = false;
            txtStatus.IsEnabled = false;
            txtStream.IsEnabled = false;
            txtSurName.IsEnabled = false;
        }

        private void FillInputBoxesData(Student student)
        {
            txtCourse.Text = student.Course.ToString();
            txtDegree.Text = student.Degree;
            txtFaculty.Text = student.Faculty;
            txtFacultyNumber.Text = student.FacultyNumber;
            txtFirstName.Text = student.FirstName;
            txtGroup.Text = student.Group.ToString();
            txtLastName.Text = student.LastName;
            txtSpecialty.Text = student.Specialty;
            txtStatus.Text = student.Status;
            txtStream.Text = student.Stream.ToString();
            txtSurName.Text = student.SurName;
        }
    }
}
