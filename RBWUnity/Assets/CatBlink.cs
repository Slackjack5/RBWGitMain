using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBlink : MonoBehaviour
{

    public float blinkTime = 4f;
    public bool blink = true;
    public Animator myAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (blink == true)
        {
            Blink();
            blink = false;
        }

    }

    void Blink()
    {
        StartCoroutine(blinkeyeball());

        IEnumerator blinkeyeball()
        {

            yield return new WaitForSeconds(blinkTime);
            myAnimation.SetBool("Blink", true);
            blink = false;
            StartCoroutine(Reset());
        }

        IEnumerator Reset()
        {

            yield return new WaitForSeconds(2);
            blink = true;
            myAnimation.SetBool("Blink", false);


        }

    }

    }
