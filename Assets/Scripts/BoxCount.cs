using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCount : MonoBehaviour
{
    public Text textbox;
    // Start is called before the first frame update
    void Start()
    {
        textbox.text = "Score: "+Controller.current.boxCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + Controller.current.boxCount.ToString();
    }
}
