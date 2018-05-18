/////////////////////////////////////////////////////
//制作者　名越大樹
//キャラクターのタイプを管理するクラス
/////////////////////////////////////////////////////

public class GetCharacterType
{
    public enum Type
    {
        None,
        Fire,
        Ice,
        Aqua,
        Leaf,
        Ground,
        Normal,
        Thunder,
        Esper,
        Fly,
        Insect,
        Poison,
    }

    public static Type GetType(int number)
    {
        switch (number)
        {
            case 1:
            case 2:
            case 3:
                return Type.Leaf;
            case 4:
            case 5:
            case 6:
            case 143:
                return Type.Fire;
            case 7:
            case 8:
            case 9:
                return Type.Aqua;
            case 149:
            case 16:
            case 17:
            case 18:
            case 21:
            case 22:
                return Type.Fly;
            case 150:
            case 151:
                return Type.Esper;
            case 144:
                return Type.Ice;
            case 145:
            case 25:
            case 26:
                return Type.Thunder;
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                return Type.Insect;
            case 19:
            case 20:
                return Type.Normal;
            case 23:
            case 24:
            case 29:
            case 30:
                return Type.Poison;
            case 27:
            case 28:

                return Type.Ground;
        }
        return Type.None;
    }
}
