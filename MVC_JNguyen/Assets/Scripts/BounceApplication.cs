using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceElement : MonoBehaviour
{
    public BounceApplication application
    {
        get
        {
            return GameObject.FindObjectOfType<BounceApplication>();
        }
    }
}


public class BounceApplication : MonoBehaviour
{
    public BounceModel model;
    public BounceView view;
    public BounceController controller;
}
