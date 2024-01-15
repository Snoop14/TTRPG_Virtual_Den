using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayCone : MonoBehaviour
{
    //gameObject I want to display
    [SerializeField]
    GameObject cone;

    //0 rotation
    Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);

    //this function displays the cone at the position the
    //gameObject was previously at
    public void showCone(GameObject movedObject)
    {
        //gets the colour of the gameObject
        Material changeColour = movedObject.GetComponent<Renderer>().sharedMaterial;
        //gets the position of the gameObject
        Vector3 lastPos = movedObject.transform.position;
        //changes the colour of the cone to match the object
        Renderer rend = cone.GetComponentInChildren<Renderer>();
        rend.material = changeColour;

        //Creates an object at that location with no rotation
        Instantiate(cone, lastPos, rotation);
    }
}
