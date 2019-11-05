using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Controller current;

    public BoxSpawner box_spawner;
    public Box currentBox;
    
    public float acceleration = 1f;
    public float min = -4f;
    public float max = 4f;
    public float boxPosition_y = 3.3f;
    public int boxCount = 0;
    public bool notOutOfTime=true;

    private void Awake()
    {
        if (current==null)
        {
            current =this;
        }
    }

    void Start()
    {
        box_spawner.BoxSpawn(boxPosition_y);
        DetectInput();
    }

    void Update()
    {
        DetectInput();
        acceleration += 0.05f * Time.deltaTime;
        min -= 0.05f * Time.deltaTime;
        max += 0.05f * Time.deltaTime;
        boxPosition_y += 0.1f * Time.deltaTime;
        
    }

    void DetectInput() 
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey("w"))
        {
            currentBox.DropBox();
        }
    }

    public void SpawnBox() 
    {
        if (notOutOfTime)
        {
            Invoke("NewBox", 0.1f);
        }
        
    }

    void NewBox() 
    {
        box_spawner.BoxSpawn(boxPosition_y);
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
    }
}
