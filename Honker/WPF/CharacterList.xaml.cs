using System;
using System.Windows;
using System.Data;

namespace Honker
{
    public partial class CharacterList : Window
    {
        private readonly Database database;

        public CharacterList(Database db)
        {
            DataView dataView;

            InitializeComponent();

            database = db;
            dataView = db.GetCharactersDataView();

            CharactersGrid.Items.Clear();
            CharactersGrid.ItemsSource = dataView;
        }

        private void FieldConfirm_Click(object sender, RoutedEventArgs e)
        {
            int id;

            if (!int.TryParse(TextBoxIndex.Text, out _))
                return;

            id = Convert.ToInt32(TextBoxIndex.Text);

            if (database.IsCharacterExists(id) == false)
                return;

            database.CurrentId = id;

            DialogResult = true;
            Close();
        }
    }
}
