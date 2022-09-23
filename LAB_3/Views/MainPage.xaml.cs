using LAB_3.Models;
using LAB_3.Services;
using LAB_3.ViewModels;
using System.ComponentModel;

namespace LAB_3;

public partial class MainPage : ContentPage
{
	private BindingList<StudentService> _studentList;
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new StudentViewModel();
    }
}

