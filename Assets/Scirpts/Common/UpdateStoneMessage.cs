//////////////////////////////////////////////////////
//制作者　名越大樹
//石のアイテムを表示させる文字のデータを管理するクラス
//////////////////////////////////////////////////////

public class UpdateStoneMessage
{
    public static string UpdateMasterMessage(string type)
    {
        switch (type)
        {
            case "fire":
                return "ほのおのカケラ";
            case "ice":
                return "こおりのカケラ";
            case "leaf":
                return "くさのカケラ";
            case "evil":
                return "あくのカケラ";
            case "water":
                return "みずのカケラ";
            case "fly":
                return "ひこうのカケラ";
            case "normal":
                return "ノーマルのカケラ";
            case "electrical":
                return "でんきのカケラ";
            case "ground":
                return "じめんのカケラ";
            case "rock":
                return "いわのカケラ";
            case "dragon":
                return "ドラゴンのカケラ";
            case "ghost":
                return "ゴーストのカケラ";
            case "insect":
                return "むしのカケラ";
            case "esper":
                return "エスパーのカケラ";
            case "poison":
                return "どくのカケラ";
            case "fight":
                return "かくとうのカケラ";
        }
        return "";
    }
}
