namespace BibliotecaBryanRivas;

public partial class ConsultaPage : ContentPage
{
	public ConsultaPage()
	{
		InitializeComponent();
	}

	private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButtonSeleccionado = sender as RadioButton;

		if (radioButtonSeleccionado != null)
		{
			string opcionSeleccionada = radioButtonSeleccionado.Content.ToString();

			if (opcionSeleccionada == "Autor")
			{
				lvAutorEditorial.ItemsSource = Biblioteca.biblioteca.Values.Select(libro => libro.Titulo.ToList());
			}
			else if (opcionSeleccionada == "Editorial") 
			{
				lvAutorEditorial.ItemsSource = Biblioteca.biblioteca.Values.Select(libro => libro.Editorial.ToList());
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