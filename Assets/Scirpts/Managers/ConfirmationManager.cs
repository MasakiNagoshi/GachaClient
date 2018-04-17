using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationManager
{
    Confirmation confirmation;
    static ConfirmationManager manager;
    public static ConfirmationManager Instance{get{ return manager; }}

    public ConfirmationManager()
    {
        manager = this;
        GameObject confrim = GameObject.Find("Confirmation");
        confirmation = confrim.GetComponent<Confirmation>();
        confirmation.gameObject.SetActive(false);
    }


    public void SetActive(bool set)
    {
        confirmation.UpdateMessage();
        confirmation.gameObject.SetActive(set);
    }
}
