using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyed_Openable : Openable
{

    protected AudioSource denied;
    protected override void Open()
    {
        Debug.Log( "Trying to open..." ); //testing
        if (GameManager.instance.hasKey) //if the player has the key
        {
            base.Open(); //open it 
        }
        else
        {
            Debug.Log( "Locked, need key to open" ); //testing
            opened = false;
        }
    }
}
