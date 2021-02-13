using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This class will only store the messages 
 * This Will be a pain in the ass but all the messages will go here
 * I was thinking of putting the messages in a text file but we would have to read
 * every subsequesnt line meaning if we want message 50 we have to read 50 lines to get it
 * We should also make this class static
 * 
 * M'emé incase you need it
 */
public class DebuffMessages : MonoBehaviour
{
    public static List<string> level1Messages;
    public static List<string> level2Messages;
    public static List<string> level3Messages;
    public static List<string> level4Messages;
    private static bool loaded = false;

    // Start is called before the first frame update
    public static void SetMessages()
    {
        if (!loaded)
        {
            loaded = true;

            level1Messages = new List<string>(48);
            level2Messages = new List<string>(29);
            level3Messages = new List<string>(24);
            level4Messages = new List<string>(31);

            /////////////theme of the level 1 messages are happy and motivational

            //Random facts
            level1Messages.Add("Scotland's National animal is the Unicorn, weird eh");
            level1Messages.Add("The longest English word is 189,819 letters long. It's a protein nicknamed tintin");
            level1Messages.Add("Different capes can get you different powers, try them all if you can");
            level1Messages.Add("The French Scrabble World Champion doesn’t even speak French, talk about fake it till you make");
            level1Messages.Add("Canadians say sorry so much so that a law was passed saying apologies aren't an admission of guilt");
            level1Messages.Add("None of the facts I have said or will say have been fact checked, think for yourselves");
            level1Messages.Add("A single strand of Spaghetti is called a Spaghetto and Confetti is Confetto");
            level1Messages.Add("Have you heard that cashews come from a fruit");
            level1Messages.Add("Goats from different countries have different accents");
            //Inspirational / happy
            level1Messages.Add("I believe in you");
            level1Messages.Add("A true man never dies ... even when he's killed");
            level1Messages.Add("Listen up player! Don't believe in yourself. Believe in me! Believe in the M'emé who believes in you!");
            level1Messages.Add("It's prononuced Meh-eh-may");
            level1Messages.Add("I bet your mother is so proud of you");
            level1Messages.Add("Wow, you're really good at this game");
            //References
            level1Messages.Add("Do I look like I know what a PNG is?");
            level1Messages.Add("I like turtles");
            level1Messages.Add("Please do not put tomatoes into fruit salad");
            level1Messages.Add("Have you heard the word. Everybody knows that M'eme is the word");
            level1Messages.Add("I love you three thousand and one. Ha I win XD "); // i Think this one is my favourite
            level1Messages.Add("Treating a woman with respect is what real men do");
            level1Messages.Add("What is better? To be born good, or to overcome your evil nature through great effort?"); //need to reword this
            level1Messages.Add("Thank you M'emé, but your mom is in another castle... I mean place");
            level1Messages.Add("Don't dead, open inside");
            level1Messages.Add("Have you ever put butter on a pop tart? You really should't it doesn't go well");
            level1Messages.Add("Life is like a box of chocolates, you know you're gonna get chocolate");
            level1Messages.Add("May the cape be with you");
            level1Messages.Add("If you like Pina coladas, and getting caught in the woods");
            level1Messages.Add("Error 404: message not found");
            level1Messages.Add("Only M'eme, master of all 10 skins could stop *boss*, but when the world needed him most, he appeared! :)");
            level1Messages.Add("You're score... IT'S OVER 9000!!!! Please ignore this message if it isn't over 9000");
            //lore
            level1Messages.Add("M'emé village was attacked by fiendish animals the day before his 18th birthday");
            level1Messages.Add("M'emé must now travel to hell to save his mother");
            level1Messages.Add("Kali, a fallen angel, Morren, demon escaped from hell, M'emé, the child of prophecy");
            level1Messages.Add("Only M'emé, the chosen one, can wield the immense power from the Cape of Sanguis");
            level1Messages.Add("M'emé was born not far from this forest where he learned to hunt and fish and hone other skills");
            level1Messages.Add("It is said that when the world needs him the most, M'emé will stop the great evil");
            level1Messages.Add("It’s dangerous to go alone, take the cape");
            level1Messages.Add("M'emeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee Jenkinssss");
            //fouth wall break
            level1Messages.Add("Make sure to check out the credits and see all the people who made this game possible :)");
            level1Messages.Add("This game was made by two university students trying to make some money so help a brother out");    //fucking love it
                                                                                                                                    //Pick up Lines
            level1Messages.Add("You smell like trash, mind if I take you out? ;)");
            level1Messages.Add("I'll be the pizza if you are box I come in");
            level1Messages.Add("If you were a vegetable you would be a CUTEcumber");
            level1Messages.Add("Hey, you’re pretty and I’m cute. Together we’d be pretty cute");
            level1Messages.Add("Can I get a kiss or should I just steal one");
            level1Messages.Add("My grandma told me demons will appear in the most beautiful thing you've ever seen. You must be the devil then.");
            //misc
            level1Messages.Add("Man I hope Kanyee East doesn't show up");



            /////////
            ///////////////// level 2 I feel like he should be sad and pessimistic
            ///

            level2Messages.Add("Get your shit together, get it all together and put it in a backpack, all your shit, so it’s together");
            level2Messages.Add("Are we caught in a landslide? Can we escape reality");
            level2Messages.Add("lubba wubba dub dub");
            level2Messages.Add("Sometimes the hardest choices require the strongest double jump abilities.");
            level2Messages.Add("Oh no the government has started summoning demons!! M'emé please save us");
            level2Messages.Add("Morren was always so nice to me even though he is a demon. I miss him so much");
            level2Messages.Add("Love isn't real, no one loves you, no one loves me, I wanna cry");
            level2Messages.Add("When a panda has more than one cub, she often only chooses one to live");
            level2Messages.Add("Cats can be allergic to you too asshole!");
            level2Messages.Add("A lot of children ask for a dad on their Christmas list.");
            level2Messages.Add("On its birthday, the Mars rover was programmed to play Happy Birthday. To itself. Alone. Just like me.");
            level2Messages.Add("I know you wanted a cake for your birthday but as it turns out, the cake is a lie T_T");
            level2Messages.Add("I used to be happy like you, but then I took an arrow to the knee");
            level2Messages.Add("Press F to pay respect");
            level2Messages.Add("I have osteoperosis");
            level2Messages.Add("You really shouldn't play this game too much");
            level2Messages.Add("What is the meaning of life? Is there a purpose behind our existence?");
            level2Messages.Add("You know, alcoholism seems like a pretty good carreer choice. Please drink responsibly.");
            level2Messages.Add("Are you WIFI? Cause I feel connected to you.");
            level2Messages.Add("I feel like a broken pencil, pointless.");
            level2Messages.Add("If you or a loved one suffer from depression, Please call a local helpline. People do care for you.");
            level2Messages.Add("Edgar Allan Poe knew what he was talking about.");
            level2Messages.Add("It's kinda cute that you think you can save the world");
            level2Messages.Add("So are you gonna be the hero, villan or the judge? At the end you will decide");
            level2Messages.Add("I want a diamond pony and I'm gonna name him stallion butt.");
            level2Messages.Add("My friends call me Hercules, or they would, if any of them were still alive. Or had existed in the first place!");
            level2Messages.Add("Apart from the crippling depression, I'm pretty happy");
            level2Messages.Add("So when did the big guy upstairs forsake us?");
            level2Messages.Add("Can you do a barrel roll?");




            /////////
            ///////////////// level 3 he should be passive aggresive now
            ///

            level3Messages.Add("While you can't “live” without WiFi, 25% of people don't have electricity. Entitled prick");
            level3Messages.Add("Puppy dog eyes mean nothing. Dogs don't feel remorse. Now you know I've been lying to you thins whole time.");
            level3Messages.Add("The numbers M'emé, what do they mean?!");
            level3Messages.Add("You know nothing, M'eme.");
            level3Messages.Add("Thats why her hair is so big her hair is full of secrets"); //
            level3Messages.Add("I did not have sexual relations with that dog.");
            level3Messages.Add("dey took err jerbs!!");
            level3Messages.Add("They may take our lives but they'll never take our (Placeholder)");
            level3Messages.Add("My name is Hercules Montoya, you killed my owner prepare to die");
            level3Messages.Add("If you were a vegetable, I wouldn't visit you at the hospital");
            level3Messages.Add("Are you free tonight or is it gonna cost me?");
            level3Messages.Add("Your father was always a better friend than you");
            level3Messages.Add("Did you fall from heaven, cause so did Satan");
            level3Messages.Add("One does not simply get the God Mode Skin");
            level3Messages.Add("I hear North Korea is beautiful this time of year, you should go");
            level3Messages.Add("Are you not entertained?! If you are remember to rate us :)");
            level3Messages.Add("Great job player, your ability to press the screen at the right time will take you far in life");
            level3Messages.Add("Did someone steal your sweat roll");
            level3Messages.Add("Covfefe");
            level3Messages.Add("Like the music? Check the credits and check out the artists.");
            level3Messages.Add("Story mode comming soon! Make sure to check it out once it releases.");
            level3Messages.Add("The world would be a much better place if you weren't in it.");
            level3Messages.Add("The world rests on your shoulders M'eme. Well we're screwed.");
            level3Messages.Add("The colusion of Tuesday has led warnings of toasters to the Martian of the juxtapositions. ");

            /////////
            ///////////////// level 4 Now he should just be an asshole and aggresive
            ///

            level4Messages.Add("Hey player! You know you're know the real reason your parents got divorced right?");
            level4Messages.Add("I hope you die of dysentery");
            level4Messages.Add("Grab them by the p***y. HAHAHAHAHA!!! What a guy");
            level4Messages.Add("Even a broken clock is useful twice a day, why aren't you");
            level4Messages.Add("Ur mom gay");
            level4Messages.Add("sHut UP StUpiD dOg!");
            level4Messages.Add("Ur dad lesbian");
            level4Messages.Add("No u");
            level4Messages.Add("It only takes one to call immigration");
            level4Messages.Add("To be or not to be that is the question. Falling to your death is the answer");
            level4Messages.Add("Fireball to the face. It's super effective. Hehehehehe");
            level4Messages.Add("What do we say to the God of death; right this way!");
            level4Messages.Add("Respect my AUTHORITAY!!");
            level4Messages.Add("Get your hands of me you damn dirty human");
            level4Messages.Add("If looks could kill you'd be completly harmless");
            level4Messages.Add("Does he look like a female dog");
            level4Messages.Add("Des-pa-ci-to, blah blah blah burito, blah blah blah, dorito");
            level4Messages.Add("Sweet dreams are made of this, who am I to dis a brie");
            level4Messages.Add("In New York - concrete jungle wet dream tomato.");
            level4Messages.Add("Why did the chicken cross the road? Because you didn’t f—ing cook it!");
            level4Messages.Add("What are you!? Thats right an idoit sandwich.");
            level4Messages.Add("Hmmmm I wonder if the initials of this game spell out anything interesting");
            level4Messages.Add("So are you stupid or are your parents cousins");
            level4Messages.Add("Are you ice cream? Because your face looks like rocky road.");
            level4Messages.Add("Are you Ebola? Because you melt my insides");
            level4Messages.Add("Was that an earthquake or did your mom just get out of bed?");
            level4Messages.Add("Size does matter bro, she lied to you.");
            level4Messages.Add("Probably could have helped you during this time but eh, I was busy.");
            level4Messages.Add("You know whats better than the God mode skin? Not being you!");
            level4Messages.Add("If the devil disguises himself as something beautiful, you must be an angel.");
            level4Messages.Add("THIS... IS... SPAR -- I mean how you doing?");

        }

    }


    /// <summary>
    /// Ideas
    /// Hotline bling
    /// Sound of silence
    /// fresh prince
    /// what is love 
    /// Bill nye
    /// macarena
    /// i believe i can fly
    /// titanic
    /// all star
    /// harder better faster stronger
    /// peanut better jelly time
    /// Dragostea din tei (numa numa guy)
    /// this is sparta
    /// chocolate rain
    /// moto moto
    /// Vsauce
    /// nyan cat
    /// let it go
    /// anaconda
    /// pen pine apple apple pen
    /// smash bros
    /// mans not hot
    /// gods plan
    /// this is america
    /// old town road
    /// 
    /// 
    /// </summary>
    /// <returns></returns>


    public static string getLevel1Message()
    {
        return level1Messages[Random.Range(0, level1Messages.Capacity - 1)];
    }

    public static string getLevel2Message()
    {
        return level2Messages[Random.Range(0, level2Messages.Capacity-1 )];
    }
    public static string getLevel3Message()
    {
        return level3Messages[Random.Range(0, level3Messages.Capacity - 1)];
    }

    public static string getLevel4Message()
    {
        return level4Messages[Random.Range(0, level4Messages.Capacity - 1)];
    }


    public static string getMessageFromLevel(int level)
    {
        Debug.Log(GameTracker.CurrentLevel + " Is the current level");
        if (level == 1)
        {
            return getLevel1Message();
        }
        else if (level == 2)
            return getLevel2Message();
        else if (level == 3)
            return getLevel3Message();
        else 
            return getLevel4Message();
    }
}
