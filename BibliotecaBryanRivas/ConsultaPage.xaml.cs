namespace BibliotecaBryanRivas;

public partial class ConsultaPage : ContentPage
{
	public ConsultaPage()
	{
		InitializeComponent();

		lvTitulo.ItemsSource = Biblioteca.biblioteca;
		lvAutorEditorial.ItemsSource = Biblioteca.biblioteca;
	}

	private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButtonSeleccionado = sender as RadioButton;

		if (radioButtonSeleccionado != null)
		{
			string opcionSeleccionada = radioButtonSeleccionado.ToString();

			if (opcionSeleccionada == "Autor")
			{
				lvAutorEditorial.ItemsSource = Biblioteca.biblioteca.Values.Select(x => x.Titulo.ToList());
			}
			else if (opcionSeleccionada == "Editorial") 
			{
				lvAutorEditorial.ItemsSource = Biblioteca.biblioteca.Values.Select(x => x.Editorial.ToList());
			}
		}
	}

	private void onLibroSeleccionado(object sender, SelectedItemChangedEventArgs e)
	{
	
	}

	private void onAutorEditorialSeleccionado(object sender, SelectedItemChangedEventArgs e) 
	{ 
		
	}

    }