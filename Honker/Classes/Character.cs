using System.Text;

namespace Honker
{
    public class Character
    {
        public string Name { get; set; }
        public string Spec { get; set; }
        public string Age { get; set; }
        public string Bloodtype { get; set; }
        public string Race { get; set; }
        public string Build { get; set; }
        public string Height { get; set; }
        public string Hairstyle { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Backstory { get; set; }
        public string RecordsGen { get; set; }
        public string RecordsMed { get; set; }
        public string RecordsSec { get; set; }
        public string RecordsEmp { get; set; }
        public string Flavor { get; set; }

        public Character(
            string name,
            string spec,
            string age,
            string bloodtype,
            string race,
            string build,
            string height,
            string hairstyle,
            string hairColor,
            string eyeColor,
            string backstory,
            string recordsGen,
            string recordsMed,
            string recordsSec,
            string recordsEmp,
            string flavor)
        {
            Name = name;
            Spec = spec;
            Age = age;
            Bloodtype = bloodtype;
            Race = race;
            Build = build;
            Height = height;
            Hairstyle = hairstyle;
            HairColor = hairColor;
            EyeColor = eyeColor;
            Backstory = backstory;
            RecordsGen = recordsGen;
            RecordsMed = recordsMed;
            RecordsSec = recordsSec;
            RecordsEmp = recordsEmp;
            Flavor = flavor;
        }

        public string GetValuesSQL()
        {
            StringBuilder values;

            values = new();

            values.Append($"'{Name}', ");
            values.Append($"'{Spec}', ");
            values.Append($"'{Age}', ");
            values.Append($"'{Bloodtype}', ");
            values.Append($"'{Race}', ");
            values.Append($"'{Build}', ");
            values.Append($"'{Height}', ");
            values.Append($"'{Hairstyle}', ");
            values.Append($"'{HairColor}', ");
            values.Append($"'{EyeColor}', ");
            values.Append($"'{Backstory}', ");
            values.Append($"'{RecordsGen}', ");
            values.Append($"'{RecordsMed}', ");
            values.Append($"'{RecordsSec}', ");
            values.Append($"'{RecordsEmp}', ");
            values.Append($"'{Flavor}'");

            return values.ToString();
        }
    }
}
