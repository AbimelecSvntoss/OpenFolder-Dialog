using System;
using System.IO;
using System.Windows.Forms;

namespace appOpenFolderDialog
{
    public partial class Form1 : Form
    {
        private string rutaSeleccionada = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaSeleccionada = ofd.SelectedPath; // Guardamos la ruta
                    listView1.Items.Clear(); // Limpiamos la lista por si había datos anteriores

                    string[] files = Directory.GetFiles(rutaSeleccionada);
                    foreach (string file in files)
                    {
                        listView1.Items.Add(file);
                    }
                }
            }
        }

        private void btnOrganize_Click(object sender, EventArgs e)
        {
            // 2. Validamos que tengamos una ruta y archivos antes de intentar organizar
            if (string.IsNullOrEmpty(rutaSeleccionada) || listView1.Items.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una carpeta con archivos primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Recorremos los archivos que cargamos en el ListView
                foreach (ListViewItem item in listView1.Items)
                {
                    string rutaArchivoOriginal = item.Text;

                    // Obtener la extensión del archivo y quitarle el punto (ej. de ".pdf" a "pdf")
                    string extension = Path.GetExtension(rutaArchivoOriginal).TrimStart('.');

                    // Si hay algún archivo sin extensión, le damos un nombre por defecto
                    if (string.IsNullOrEmpty(extension))
                    {
                        extension = "SinExtension";
                    }

                    // 4. Construimos la ruta de la nueva subcarpeta (usando el nombre de la extensión)
                    // Ponerlo en mayúsculas (ToUpper) hace que las carpetas se vean más uniformes (ej. "PDF", "JPG")
                    string rutaSubcarpeta = Path.Combine(rutaSeleccionada, extension.ToUpper());

                    // Si la subcarpeta no existe, la creamos
                    if (!Directory.Exists(rutaSubcarpeta))
                    {
                        Directory.CreateDirectory(rutaSubcarpeta);
                    }

                    // 5. Construimos la ruta de destino exacta donde se pegará la copia del archivo
                    string nombreArchivo = Path.GetFileName(rutaArchivoOriginal);
                    string rutaArchivoDestino = Path.Combine(rutaSubcarpeta, nombreArchivo);

                    // 6. Copiamos el archivo (el tercer parámetro 'true' indica que si ya existe un archivo igual, lo sobreescribe)
                    File.Copy(rutaArchivoOriginal, rutaArchivoDestino, true);
                }

                MessageBox.Show("Los archivos han sido copiados y organizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al organizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}