using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box;

    public void BoxSpawn(float y)
    {
        GameObject box_Obj = Instantiate(box);

        Vector3 temp = transform.position;
        temp.z = 1f;
        temp.y = y;
        
        box_Obj.transform.position = temp;
        
    }
}
