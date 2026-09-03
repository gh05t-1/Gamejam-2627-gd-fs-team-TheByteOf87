using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Catch.StartFishing.Invoke(false);
        Catch.StartFishing.Invoke(true);
    }
}
