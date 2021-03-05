using System;

namespace Quest
{
    public class Prize
    {
        private string _text;

        // Constructor
        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                for (int i = 0; i < adventurer.Awesomeness; i++)
                {
                    Console.Write($"{this._text} ");
                }
            }
            else
            {
                Console.WriteLine($"{adventurer.Name} does not have an impressive level of awesomeness.");
            }
        }
    }
}

