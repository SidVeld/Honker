using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Honker.WPF;

namespace Honker
{
    public partial class MainWindow : Window
    {
        private readonly Database database;
        private readonly Random rnd;

        public MainWindow()
        {
            InitializeComponent();

            rnd = new();
            database = new();

            SetTitle();
            CenterWindow();
            LoadCharacter();
        }

        private void SetTitle()
        {
            List<string> titles;
            int index;

            titles = new()
            {
                "Who honked up?",
                "Where is the Mime?",
                "Call the shuttle!",
                "Oh no, the HoS mega sus",
                "I want to be banana",
                "Clowns. Together. Strong.",
                "HONK!",
                "For the Honk-Mother!",
                "Remember, Mime: No shitcurity.",
                "SPACE!",
                "GET DAT FUKKEN DISK!"
            };

            index = rnd.Next(titles.Count);
            Title += $" | {titles[index]}";
        }

        private void CenterWindow()
        {
            double screenWidth;
            double screenHeight;
            double windowWidth;
            double windowHeight;

            screenWidth = SystemParameters.PrimaryScreenWidth;
            screenHeight = SystemParameters.PrimaryScreenHeight;
            
            windowWidth = Width;
            windowHeight = Height;

            Left = (screenWidth / 2) - (windowWidth / 2);
            Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void OpenTextEdit(object sender, RoutedEventArgs e)
        {
            Button button;
            TextEditWindow textEditWindow;
            
            button = sender as Button;

            if ((button.Tag != null) && (button.Tag.ToString() == "big"))
                textEditWindow = new(button, true);
            else
                textEditWindow = new(button);

            textEditWindow.ShowDialog();
        }

        private void OpenCharacterList(object sender, RoutedEventArgs e)
        {
            CharacterList characterList;

            characterList = new(database);

            if (characterList.ShowDialog() == false)
                return;

            LoadCharacter();
        }

        private void CreateNewCharacter(object sender, RoutedEventArgs e)
        {
            ConfirmWindow confirmWindow;
            string message;

            message = "This button creates new character and loads his data to this window. " +
                      "You current character's  edtis will be lost, if you didn't save them. " +
                      "If you sure, that character saved and ready to write new character, " +
                      "press the button.";
            confirmWindow = new(message);

            if (confirmWindow.ShowDialog() == false)
                return;

            database.InsertNewCharacterTemplate();
            LoadCharacter();
        }

        private void SaveCharacter(object sender, RoutedEventArgs e)
        {
            Character character;
            Dictionary<string, string> buttonsContent;

            buttonsContent = CollectButtonsContent();
            character = CharacterFactory.CreateCharacterByDict(buttonsContent);
            database.UpdateCharacter(character);
        }

        private void DeleteCharacter(object sender, RoutedEventArgs e)
        {
            ConfirmWindow confirmWindow;
            string message;

            message = "This button deletes current characters. " +
                      "Are you sure that you want to kill your Honk-Child?";
            confirmWindow = new(message);

            if (confirmWindow.ShowDialog() == false)
                return;

            database.DeleteCharacter();
            LoadCharacter();
        }

        private void LoadCharacter()
        {
            Character selectedCharacter;
            Dictionary<string, string> characterData;

            characterData = database.GetCharacterDataById();
            selectedCharacter = CharacterFactory.CreateCharacterByDict(characterData);
            FillFields(selectedCharacter);
        }

        private void FillFields(Character character)
        {
            FieldName.Content = character.Name;
            FieldSpec.Content = character.Spec;
            FieldAge.Content = character.Age;
            FieldBloodtype.Content = character.Bloodtype;
            FieldRace.Content = character.Race;
            FieldBuild.Content = character.Build;
            FieldHeight.Content = character.Height;
            FieldHairStyle.Content = character.Hairstyle;
            FieldHairColor.Content = character.HairColor;
            FieldEyeColor.Content = character.EyeColor;
            FieldBackstory.Content = character.Backstory;
            FieldRecordsGen.Content = character.RecordsGen;
            FieldRecordsMed.Content = character.RecordsMed;
            FieldRecordsSec.Content = character.RecordsSec;
            FieldRecordsEmp.Content = character.RecordsEmp;
            FieldFlavor.Content = character.Flavor;
        }

        private Dictionary<string, string> CollectButtonsContent()
        {
            string name;
            string spec;
            string age;
            string bloodtype;
            string race;
            string build;
            string height;
            string hairstyle;
            string hairColor;
            string eyeColor;
            string backstory;
            string recordsGen;
            string recordsMed;
            string recordsSec;
            string recordsEmp;
            string flavor;
            Dictionary<string, string> buttonsContent;

            name = FieldName.Content.ToString();
            spec = FieldSpec.Content.ToString();
            age = FieldAge.Content.ToString();
            bloodtype = FieldBloodtype.Content.ToString();
            race = FieldRace.Content.ToString();
            build = FieldBuild.Content.ToString();
            height = FieldHeight.Content.ToString();
            hairstyle = FieldHairStyle.Content.ToString();
            hairColor = FieldHairColor.Content.ToString();
            eyeColor = FieldEyeColor.Content.ToString();
            backstory = FieldBackstory.Content.ToString();
            recordsGen = FieldRecordsGen.Content.ToString();
            recordsMed = FieldRecordsMed.Content.ToString();
            recordsSec = FieldRecordsSec.Content.ToString();
            recordsEmp = FieldRecordsEmp.Content.ToString();
            flavor = FieldFlavor.Content.ToString();

            buttonsContent = new()
            {
                { "name", name },
                { "spec", spec },
                { "age", age },
                { "bloodtype", bloodtype },
                { "race", race },
                { "build", build },
                { "height", height },
                { "hairstyle", hairstyle },
                { "hairColor", hairColor },
                { "eyeColor", eyeColor },
                { "backstory", backstory },
                { "recordsGen", recordsGen },
                { "recordsMed", recordsMed },
                { "recordsSec", recordsSec },
                { "recordsEmp", recordsEmp },
                { "flavor", flavor }
            };

            return buttonsContent;
        }
    }
}
