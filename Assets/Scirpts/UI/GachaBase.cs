////////////////////////////////////////////////
//制作者　名越大樹
//ガチャの種類の基底クラス
////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public abstract class GachaBase : MonoBehaviour
{
    public abstract void Gacha();//ガチャを行う時の処理
    public abstract void Confirmation();//ガチャを行うときの確認に関する処理
    public abstract Text GetTicket();
    public abstract int GetCount();
    public abstract string GetRate();
    public abstract void SetUseCount(int usecount);
    public abstract int GetUseCount();
    public abstract void AddUseCount(bool value);
    public abstract int GetMaxUseCount();
    public abstract string GetGachaRate();
}
