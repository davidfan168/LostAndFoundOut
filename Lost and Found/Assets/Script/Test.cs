using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameEvent ev;

    public void Click()
    {
        ev.Raise();
    }
}
