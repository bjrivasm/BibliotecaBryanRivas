
namespace BibliotecaBryanRivas;

public partial class AltaPage : ContentPage
{
	private string imagePath;

	public AltaPage()
	{
		InitializeComponent();
	}

    private void onCleanClicked(object sender, EventArgs e)
    {
        limpiarCampos();
    }

    private void limpiarCampos()
    {
        entryTitulo.Text = string.Empty;
        entryAutor.Text = string.Empty;
        entryEditorial.Text = string.Empty;
        imagenLibro.Source = null;

    }

    private async void onSelectImageClicked(object sender, EventArgs e)
	{
		PickOptions pickOptions = new PickOptions { PickerTitle = "Seleccione una imagen", FileTypes = FilePickerFileType.Images };
		pickOptions.PickerTitle = "Por favor seleccione una portada para el libro";

		try
		{
			var file = await FilePicker.Default.PickAsync(pickOptions);
			if (file != null)
			{
				imagePath = file.FullPath;
                using var stream = await file.OpenReadAsync();
                var image = ImageSource.FromStream(() => stream);
				imagenLibro.Source = ImageSource.FromFile(imagePath);
            }
		}
		catch(Exception ex)
		{
			await DisplayAlert("ERROR", $"No se puedo seleccionar la imagen: {ex.Message}", "Aceptar");
		}
	}

    private void onSaveClicked(object sender, EventArgs e)
    {
        string titulo = entryTitulo.Text;
        string autor = entryAutor.Text;
        string editorial = entryEditorial.Text;

        if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(autor) || string.IsNullOrEmpty(editorial) || string.IsNullOrEmpty(imagePath))
        {
            DisplayAlert("Error", "Por favor, completa todos los campos y selecciona una imagen.", "OK");
            return;
        }

        if (Biblioteca.biblioteca.ContainsKey(titulo))
        {
            DisplayAlert("ERROR", "El libro introducido ya existe en la biblioteca", "Aceptar");
        }
        else
        {
            Libro libroNuevo = new Libro { Titulo = titulo, Autor = autor, Editorial = editorial, Portada = imagePath };

            Biblioteca.biblioteca.Add(titulo, libroNuevo);

            DisplayAlert("", "El libro se ha añadido a la biblioteca", "Aceptar");
            limpiarCampos();
        }
    }

}