using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    public static DeadScreen instance;

    public bool isEnd = false;

    private void Awake()
    {
        instance = this;
        isEnd = true;
    }
}
