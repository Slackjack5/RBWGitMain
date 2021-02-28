using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class risingWater : MonoBehaviour
{

    public bool isRising = false;
    public bool isFalling = false;
    public GameObject stopper;
    public float speed = 5f;
    public GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRising==true)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().fadeIdleOcean = true;
            foreach (GameObject lightuser in objs)
            {
                lightuser.SetActive(true);
            }
        }
        if (isFalling == true)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().fadeIdleOcean = false;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().fadeReturn = true;
            //GameObject.Find("AudioManager").GetComponent<AudioManager>().fadeIdleOcean = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRising)
        {
            foreach (GameObject enemy in objs)
            {
                enemy.SetActive(true);
            }
        }

        isRising = false;
        if(isFalling==true)
        {
            GameObject.Find("ArcadeMachine").GetComponent<ArcadeMachine>().isActive = true;
            isFalling = false;
            foreach (GameObject enemy in objs)
            {
                enemy.SetActive(false);
            }
        }
        
        Debug.Log("water stopped");
    }
}
