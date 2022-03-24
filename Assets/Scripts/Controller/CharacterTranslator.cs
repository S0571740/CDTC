using System.Collections.Generic;

public class CharacterTranslator{

    public static char LEFT_RIGHT = '\u2500';
    public static char TOP_BOTTOM = '\u2502';
    public static char LEFT_BOTTOM = '\u2510';
    public static char BOTTOM_RIGHT = '\u250C';
    public static char RIGHT_TOP = '\u2514';
    public static char TOP_LEFT = '\u2518';
    public static char TOP_LEFT_RIGHT = '\u2534';
    public static char LEFT_TOP_BOTTOM = '\u2524';
    public static char BOTTOM_LEFT_RIGHT = '\u252C';
    public static char RIGHT_BOTTOM_TOP = '\u251C';
    public static char CROSS = '\u253C';

    public static List<char> getChars(){
        List<char> chars = new List<char>();
        chars.Add(LEFT_RIGHT);
        chars.Add(TOP_BOTTOM);
        chars.Add(LEFT_BOTTOM);
        chars.Add(BOTTOM_RIGHT);
        chars.Add(RIGHT_TOP);
        chars.Add(TOP_LEFT);
        chars.Add(TOP_LEFT_RIGHT);
        chars.Add(LEFT_TOP_BOTTOM);
        chars.Add(BOTTOM_LEFT_RIGHT);
        chars.Add(RIGHT_BOTTOM_TOP);
        chars.Add(CROSS);
        return chars;
    }
}
