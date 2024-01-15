using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    //scrollview objects
    [SerializeField] GameObject MonsterScroll;
    [SerializeField] GameObject EnvironmentScroll;

    //location for the objects to spawn on top of
    [SerializeField] GameObject ObjectSpawn;

    //parent of the spawned objects
    [SerializeField] Transform miniMonstersParent;
    [SerializeField] Transform miniEnvironmentParent;

    //location and rotation for objects to spawn at
    private Vector3 spawnLocation;
    private Quaternion spawnRot;

    // Start is called before the first frame update
    void Start()
    {
        //spawn location is linked to ObjectSpawn's position
        spawnLocation = ObjectSpawn.transform.position;
        spawnLocation.y += 1.2f;
    }

    public void OnMonsterButton()
    {
        //when monster button is pressed deactivate the Environment scroll
        EnvironmentScroll.SetActive(false);
        //while activating the monster scroll
        MonsterScroll.SetActive(true);
    }

    public void OnEnvironmentButton()
    {
        //when environment button is pressed deactivate the monster scroll
        MonsterScroll.SetActive(false);
        //whil activating the environment scroll
        EnvironmentScroll.SetActive(true);
    }

    //spawns in the monster of the button that was pressed
    public void SpawnMonsterByName(Transform objectName)
    {
        //takes the name of the object
        string name = objectName.name;
        //removes the last 6 letters, which should be "button"
        name = name.Remove(name.Length - 6);
        //searches the Resources folder for a prefab with the same name
        GameObject spawnMonster = Resources.Load(name, typeof(GameObject)) as GameObject;
        spawnRot = spawnMonster.transform.rotation;
        spawnRot.y += 180f;
        //spawns the prefab upright on top of the spawnlocation
        Instantiate(spawnMonster, spawnLocation, spawnRot, miniMonstersParent);
    }

    //spawns in the environment of the button that was pressed
    public void SpawnEnvironmentByName(Transform objectName)
    {
        //takes the name of the object
        string name = objectName.name;
        //removes the last 6 letters, which should be "button"
        name = name.Remove(name.Length - 6);
        //searches the Resources folder for a prefab with the same name
        GameObject spawnEnvironment = Resources.Load(name, typeof(GameObject)) as GameObject;
        spawnRot = spawnEnvironment.transform.rotation;
        //spawns the prefab upright on top of the spawnlocation
        Instantiate(spawnEnvironment, spawnLocation, spawnRot, miniEnvironmentParent);
    }
}
