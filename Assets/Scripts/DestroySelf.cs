using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    //variable to change on the object that script is attached to
    [SerializeField]
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        //destroy the object after the specified number of seconds
        Destroy(gameObject, seconds);
    }
}
