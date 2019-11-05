using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 90f;
    public Text textbox;
    public Text textbox_2;
    void Start()
    {
        textbox.text = timeStart.ToString();
    }

    void Update()
    {
        if (timeStart <= 0)
        {
            Invoke("Restart", 15f);
            textbox_2.text = "Congratulations! You Survived! Your Score Is: " + Controller.current.boxCount;
            Controller.current.notOutOfTime = false;
        }
        else
        {
            timeStart -= Time.deltaTime;
            textbox.text = Mathf.Round(timeStart).ToString();
        }
    }
    void Restart() 
    {
        Controller.current.Restart();
    }
}
