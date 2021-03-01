using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public GameObject seaWater;
    public Animator myFade;


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
        myFade.SetBool("flash", true);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().fadeWater = false;

    }

    public void fallWater()
    {
        Debug.Log("I'm lowering the water dummy");
        myFade.SetBool("Flash", true);
        GameObject.Find("waterObject").GetComponent<risingWater>().isFalling = true;
        FindObjectOfType<AudioManager>().PlaySound("Water", UnityEngine.Random.Range(.90f, 1f));
        GameObject.Find("AudioManager").GetComponent<AudioManager>().fadeWater = false;

    }

}
