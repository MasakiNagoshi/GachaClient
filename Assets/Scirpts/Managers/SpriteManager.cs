/////////////////////////////////////////////////
//制作者　名越大樹
//Spriteを管理するクラス
/////////////////////////////////////////////////

using UnityEngine;

public class SpriteManager
{
    Sprite[] sprites;
    public enum ReadStatus
    {
        Tickets,
    }

    static SpriteManager instance;
    public static SpriteManager Instance { get { return instance; } }

    public SpriteManager(ReadStatus status)
    {
        instance = this;
        ReadData(status);
    }
    void ReadData(ReadStatus status)
    {
        switch (status)
        {
            case ReadStatus.Tickets:
                sprites = Resources.LoadAll<Sprite>("Image/Ticket");
                break;
        }
    }

    public Sprite GetSprite(int number)
    {
        return sprites[number];
    }
}
