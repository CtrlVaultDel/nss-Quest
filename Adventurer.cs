namespace Quest
{
    // An instance of the Adventurer class is an object that will undergo some challenges
    public class Adventurer
    {
        // This is an "immutable" property. It only has a "get".
        // The only place the Name can be set is in the Adventurer constructor
        // Note: the constructor is defined below.
        public string Name { get; }

        // Immutable property
        public Robe ColorfulRobe { get; }

        public Hat AdventureHat { get; }

        // This is a mutable property it has a "get" and a "set"
        //  So it can be read and changed by any code in the application
        public int Awesomeness { get; set; }

        // A constructor to make a new Adventurer object with a given name
        public Adventurer(string name, Robe colorfulRobe, Hat adventureHat)
        {
            Name = name;
            ColorfulRobe = colorfulRobe;
            AdventureHat = adventureHat;
            Awesomeness = 50;
        }


        // This method returns a string that describes the Adventurer's status
        // Note one way to describe what this method does is:
        //   it transforms the Awesomeness integer into a status string
        public string GetAdventurerStatus()
        {
            string status = "okay";
            if (Awesomeness >= 75)
            {
                status = "great";
            }
            else if (Awesomeness < 25 && Awesomeness >= 10)
            {
                status = "not so good";
            }
            else if (Awesomeness < 10 && Awesomeness > 0)
            {
                status = "barely hanging on";
            }
            else if (Awesomeness <= 0)
            {
                status = "not gonna make it";
            }

            return $"Adventurer, {Name}, is {status}";
        }

        public string GetDescription()
        {
            string robeDescription = "";
            for (int i = 0; i < this.ColorfulRobe.Colors.Count; i++)
            {
                if (this.ColorfulRobe.Colors.Count - i != 1)
                {
                    robeDescription += this.ColorfulRobe.Colors[i];
                }
                else
                {
                    robeDescription += $" and {this.ColorfulRobe.Colors[i]}";
                }
            }
            return $"{this.Name} is currently wearing a {this.AdventureHat.ShininessDescription()} hat and a {robeDescription} robe that is {this.ColorfulRobe.Length} inches long";
        }
    }
}