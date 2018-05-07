/////////////////////////////////////////////
//制作者　名越大樹
//ポケモンの名前を管理するクラス
/////////////////////////////////////////////

public class DicitonaryName
{
    static DicitonaryName instance;

    public static DicitonaryName Instance
    {
        get
        {
            if (instance == null)
            {
                DicitonaryName dictionary = new DicitonaryName();
            }
            return instance;
        }
    }

    DicitonaryName()
    {
        instance = this;
    }

    public string GetName(int number)
    {
        switch (number)
        {
            case 3:
                return "フシギバナ";
            case 6:
                return "リザードン";
            case 9:
                return "カメックス";
            case 144:
                return "フリーザー";
            case 146:
                return "ファイアー";
            case 145:
                return "サンダー";
            case 150:
                return "ミュウツー";
            case 151:
                return "ミュウ";
        }
        return null;
    }
}
