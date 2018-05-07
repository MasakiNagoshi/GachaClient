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
        Flight,
    }

    public static Type GetType(int number)
    {
        switch (number)
        {
            case 3:
                return Type.Leaf;
            case 6:
            case 143:
                return Type.Fire;
            case 9:
                return Type.Aqua;
            case 149:
                return Type.Flight;
            case 150:
            case 151:
                return Type.Esper;
            case 144:
                return Type.Ice;
            case 145:
                return Type.Thunder;
        }
        return Type.None;
    }
}
