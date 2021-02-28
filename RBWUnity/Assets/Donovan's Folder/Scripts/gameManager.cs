using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public GameObject seaWater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void riseWater()
    {
        Debug.Log("I'm rising the water dummy");
        GameObject.Find("waterObject").GetComponent<risingWater>().isRising = true;
    }

    public void fallWater()
    {
        Debug.Log("I'm lowering the water dummy");
        GameObject.Find("waterObject").GetComponent<risingWater>().isFalling = true;
    }

}
