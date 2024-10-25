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

			if (opcionSeleccionada.Equals("Autor"))
			{
				lvAutorEditorial.ItemsSource = Biblioteca.biblioteca.Values.Select(libro => libro.Autor).Distinct().ToList();
			}
			else if (opcionSeleccionada.Equals("Editorial")) 
			{
				lvAutorEditorial.ItemsSource = Biblioteca.biblioteca.Values.Select(libro => libro.Editorial).Distinct().ToList();
			}
		}
	}
    private void onAutorEditorialSeleccionado(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            string seleccion = e.SelectedItem.ToString();

            if (radioAutor.IsChecked)
            {
                lvTitulo.ItemsSource = Biblioteca.biblioteca.Values.Where(x => x.Autor.Equals(seleccion)).Select(x => x.Titulo).ToList();
            }
            else if (radioEditorial.IsChecked)
            {
                lvTitulo.ItemsSource = Biblioteca.biblioteca.Values.Where(x => x.Editorial.Equals(seleccion)).Select(x => x.Titulo).ToList();
            }
        }
    }

    private void onTituloSeleccionado(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			string tituloLibro = e.SelectedItem.ToString();

			imagenPortada.Source = ImageSource.FromFile(Biblioteca.biblioteca[tituloLibro].Portada);
		}
    }

}