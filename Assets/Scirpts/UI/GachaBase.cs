using UnityEngine;
using UnityEngine.UI;
public abstract class GachaBase : MonoBehaviour
{
    public abstract void Gacha();
    public abstract void Confirmation();
    public abstract Text GetTicket();
    public abstract int GetCount();
    public abstract string GetRate();
    public abstract void SetUseCount(int usecount);
    public abstract int GetUseCount();
    public abstract void AddUseCount(bool value);
    public abstract int GetMaxUseCount();
    public abstract string GetGachaRate();
}
