using System.Collections.Generic;
using Api_Disney.Models;

namespace TestApp.UnitTest.MockData;

public class CharacterMockData
{
    public static List<Character> GetCharacters()
    {
        return new List<Character>{
            new Character{
                CharacterID = 1,
                Image_url = "https://th.bing.com/th/id/R.5656891e8545420797986bc407fb10c2?rik=XQwsfwVIHrGtTA&pid=ImgRaw&r=0&sres=1&sresct=1",
                Name = "Elsa",
                Age = 21,
                Weight = 60,
                Story = "A blizzard girl"
            },
            new Character{
                CharacterID = 2,
                Image_url = "https://th.bing.com/th/id/OIP.XpU4IG43adYdZ5BDgMqblQHaMo?pid=ImgDet&rs=1",
                Name = "Mickey",
                Age = 85,
                Weight = 2,
                Story = "A talkative mouse"
            },
            new Character{
                CharacterID = 3,
                Image_url = "https://static.wikia.nocookie.net/disney/images/7/7b/Pluto.PNG/revision/latest/scale-to-width-down/262?cb=20170628205507",
                Name = "Pluto",
                Age = 85,
                Weight = 20,
                Story = "The Mickey's dog"
            },
            new Character{
                CharacterID = 4,
                Image_url = "https://static.wikia.nocookie.net/disney/images/7/7b/Pluto.PNG/revision/latest/scale-to-width-down/262?cb=20170628205507",
                Name = "Minnie",
                Age = 85,
                Weight = 1,
                Story = "The Mickey's girlfriend"
            },
        };
    }

    public static List<Character> EmptyCharacters()
    {
        return new List<Character>();
    }

    public static Character InsertCharacter()
    {
        return new Character{
            Name = "Goofy",
            Story = "A silly dog"
        };
    }
}


