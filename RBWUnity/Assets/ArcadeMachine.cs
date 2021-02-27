using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour
{

    private bool isActive = true;
    private bool eventStarted = false;
    private int randEvent = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (isActive)
        {
            Debug.Log("Don't Click me Dumbass");
            isActive = false;
            //Randomize World
            randEvent = Random.Range(0, 1);
            //Generate World
            startEvent();

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void startEvent()
    {
        //Initiate Build Up
        StartCoroutine(isBuildingUp());

        IEnumerator isBuildingUp()
        {
            yield return new WaitForSeconds(3);

            if (randEvent == 0)
            {
                spawnOcean();
            }
        }

    }
    void spawnOcean()
    {
        eventStarted = true;
        Debug.Log("Ocean is being created");

        //Initiate Build Up
        StartCoroutine(isBeingCreated());

        IEnumerator isBeingCreated()
        {
            yield return new WaitForSeconds(4);
            generateOcean();
        }
    }

    void generateOcean()
    {
        Debug.Log("Ocean is created");
    }

    }
