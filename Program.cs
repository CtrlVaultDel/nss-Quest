using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter an adventurer's name
            Console.Write("What is your adventurer's name? > ");
            string adventurerName = Console.ReadLine();

            // Will keep track of how many challenges the user completed successfully
            int successfulChallenges = 0;

            // Used in game's while loop
            string keepPlaying = "YES";

            // LOOP BEGIN
            while (keepPlaying == "YES")
            {
                // Create a few challenges for our Adventurer's quest
                // The "Challenge" Constructor takes three arguments
                //   the text of the challenge
                //   a correct answer
                //   a number of awesome points to gain or lose depending on the success of the challenge
                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);
                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50);

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
        1) John
        2) Paul
        3) George
        4) Ringo
    ",
                    4, 20
                );

                Challenge milesPerHour = new Challenge("How many miles would you travel if you went 60mph for an hour?", 60, 25);

                Challenge minutesCalc = new Challenge("How many seconds is in 1.25 minutes?", 75, 20);

                Challenge[] challengeArray = { twoPlusTwo, theAnswer, whatSecond, guessRandom, favoriteBeatle, milesPerHour, minutesCalc };
                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // create a new robe for the adventurer
                Robe robe = new Robe();
                robe.Colors.Add("green");
                robe.Colors.Add("red");
                robe.Length = 90.0m;

                // Create a new hat for the adventurer
                Hat hat = new Hat();
                hat.ShininessLevel = 5;

                // Create a new prize for the adventurer
                Prize prize = new Prize("Water Bottle");

                // Make a new "Adventurer" object using the "Adventurer" class
                Adventurer theAdventurer = new Adventurer(adventurerName, robe, hat);
                Console.WriteLine(theAdventurer.GetDescription());
                Console.WriteLine();

                // Add extra points from prior successful challenges to awesomeness level
                theAdventurer.Awesomeness += (successfulChallenges * 10);

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>();

                // Prepare random number variable outside of loop
                Random rndm = new Random();

                // Put 5 random challenges from the challengesArray in the challenges List
                for (int i = 0; i < 5; i++)
                {
                    int randomChallenge = rndm.Next(0, challengeArray.Length);
                    Challenge c = challengeArray[randomChallenge];
                    challenges.Add(c);
                }


                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in challenges)
                {
                    bool passed = challenge.RunChallenge(theAdventurer);
                    if (passed)
                    {
                        successfulChallenges++;
                        Console.WriteLine($"Successful Challenges: {successfulChallenges}");
                    }
                    Console.WriteLine($"{theAdventurer.Name} has {theAdventurer.Awesomeness} points.");
                    Console.WriteLine();
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                prize.ShowPrize(theAdventurer);

                Console.Write("Would you like to try again?(Yes/No)");
                string tempAnswer = Console.ReadLine();
                tempAnswer = tempAnswer.ToUpper();
                Console.WriteLine(tempAnswer);
                if (tempAnswer == "YES")
                {
                    Console.Clear();
                    Console.WriteLine("Excellent choice, another round of quest coming up!");
                }
                else if (tempAnswer == "NO")
                {
                    Console.WriteLine("Sad to see you go, but I know you'll be back.");
                    keepPlaying = tempAnswer;
                }
                else if (tempAnswer != "YES" && tempAnswer != "NO")
                {
                    Console.WriteLine("That is not a proper response, fine, I'll see you next time");
                    keepPlaying = tempAnswer;
                }
                Console.WriteLine();
            }
        }
    }
}