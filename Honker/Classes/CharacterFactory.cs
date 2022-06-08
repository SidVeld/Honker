using System.Collections.Generic;

namespace Honker
{
    public class CharacterFactory
    {
        public static Character CreateChracterTemplate()
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
            Character character;

            name = "Honker";
            spec = "Space Clown";
            age = "69 years";
            bloodtype = "H+";
            race = "Human (Clown-man)";
            build = "Bulky";
            height = "High";
            hairstyle = "Eggman";
            hairColor = "Rainbow";
            eyeColor = "Pink";
            backstory = "Space clown from deep space!";
            recordsGen = "Hello, this is Honkers records!";
            recordsMed = "Dont give him fookin space lube!";
            recordsSec = "Beat him to death! ~ Head of Security";
            recordsEmp = "His salary - bananas.";
            flavor = "This clown has a big and juicy nose!";

            character = new(
                name,
                spec,
                age,
                bloodtype,
                race,
                build,
                height,
                hairstyle,
                hairColor,
                eyeColor,
                backstory,
                recordsGen,
                recordsMed,
                recordsSec,
                recordsEmp,
                flavor
            );
            
            return character;
        }
        public static Character CreateCharacterByDict(Dictionary<string, string> dict)
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
            Character character;

            name = dict["name"];
            spec = dict["spec"];
            age = dict["age"];
            bloodtype = dict["bloodtype"];
            race = dict["race"];
            build = dict["build"];
            height = dict["height"];
            hairstyle = dict["hairstyle"];
            hairColor = dict["hairColor"];
            eyeColor = dict["eyeColor"];
            backstory = dict["backstory"];
            recordsGen = dict["recordsGen"];
            recordsMed = dict["recordsMed"];
            recordsSec = dict["recordsSec"];
            recordsEmp = dict["recordsEmp"];
            flavor = dict["flavor"];

            character = new(
                name,
                spec,
                age,
                bloodtype,
                race,
                build,
                height,
                hairstyle,
                hairColor,
                eyeColor,
                backstory,
                recordsGen,
                recordsMed,
                recordsSec,
                recordsEmp,
                flavor
            );

            return character;
        }
    }
}
