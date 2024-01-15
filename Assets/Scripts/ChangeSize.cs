using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSize : MonoBehaviour
{
    //vector to store the scale values
    private Vector3 objectScale;

    //change size of object based on the dropdown value
    public void changeSize(Dropdown dropdown)
    {
        //initial scale values
        objectScale.x = 0.046f;
        objectScale.y = 0.046f;
        objectScale.z = 0.046f;

        //store dropdown val in variable
        int val = dropdown.value;
        //size will be changed by multiplying it with this var
        float mult;

        //the case for the smallest object in the dropdown
        if(val == 0)
        {
            //smallest object is smaller than initial scale
            mult = 0.5f;
        }
        else
        {
            //other wise the multiplicator value is equal to the dropdown val
            mult = val;
        }
        //change size of connected gameObject based on mult variable
        gameObject.transform.localScale = new Vector3(objectScale.x * mult, 
                                                      objectScale.y * mult, 
                                                      objectScale.z * mult);
    }

    private void OnApplicationQuit()
    {
        //resets the gameObjects scale values to the initial values
        gameObject.transform.localScale = new Vector3(0.046f, 0.046f, 0.046f);
    }
}
