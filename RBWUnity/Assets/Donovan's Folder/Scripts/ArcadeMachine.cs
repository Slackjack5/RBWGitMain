using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour
{

    public bool isActive = true;
    private bool eventStarted = false;
    private int randEvent = 0;

    public bool eventOcean = false;
    public bool canEnd = false;

    //Refernces

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
        if(!isActive)
        {
            if(eventOcean=true && canEnd == true)
            {
                eventOcean = false;
                canEnd = false;
                Debug.Log("making water fall");
                FindObjectOfType<gameManager>().fallWater();
            }

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
                eventOcean = true;
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
            canEnd = true;
            FindObjectOfType<gameManager>().riseWater();
            yield return new WaitForSeconds(3);
            generateOcean();
        }
    }

    void generateOcean()
    {
        Debug.Log("Ocean is created");
        canEnd = true;
    }

    }
