using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager
{
    Sprite[] sprites;
    public enum ReadStatus
    {
        Tickets,
    }

    static SpriteManager instance;
    public SpriteManager(ReadStatus status)
    {
        instance = this;
        ReadData(status);
    }
    public static SpriteManager Instance{ get { return instance; } }
    void ReadData(ReadStatus status)
    {
        switch(status)
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
