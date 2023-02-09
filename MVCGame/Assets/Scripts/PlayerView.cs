using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BounceElement
{
    private void OnCollisionEnter(Collision collision)
    {
        application.controller.MoveCunt();
    }
}
