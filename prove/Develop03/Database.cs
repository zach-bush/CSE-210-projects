public class Database
{
    private string[] _texts = 
    {
        "For he that diligently aseeketh shall find; and the bmysteries of God shall be unfolded unto them, by the power of the cHoly Ghost, as well in these times as in times of old, and as well in times of old as in times to come; wherefore, the dcourse of the Lord is one eternal round.",
        "And now, my sons, remember, remember that it is upon the arock of our Redeemer, who is Christ, the Son of God, that ye must build your bfoundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty cstorm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.",
        "Wherefore, by faith was the law of Moses given. But in the agift of his Son hath God prepared a more bexcellent way; and it is by faith that it hath been fulfilled.",
        "And if men come unto me I will show unto them their aweakness. I bgive unto men weakness that they may be humble; and my cgrace is sufficient for all men that dhumble themselves before me; for if they humble themselves before me, and have faith in me, then will I make eweak things become strong unto them.",
        "23 Awake, my sons; put on the armor of arighteousness. Shake off the bchains with which ye are bound, and come forth out of obscurity, and arise from the dust."
    };

    private string[] _books = 
    {
        "",
    };

    private string[] _chapters = 
    {
        "",
    };

    private string[] _verses = 
    {
        "",
    };

    public Scripture GetScripture()
    {
        return new Scripture(_books[0], _chapters[0], _verses[0], _texts[0]);
    }
}