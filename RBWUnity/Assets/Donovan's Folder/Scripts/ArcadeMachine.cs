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
    public Animator myLever;
    public Animator myArcade;
    public bool pullLever = true;
    public GameObject blackScreen;
    public GameObject blackScreenFront;
    public bool eventCreepy; 

    //Array
    public GameObject[] eyeballs;
    //Refernces

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        
        if (pullLever)
        {
            myLever.SetBool("pulled", true);
            FindObjectOfType<AudioManager>().PlaySound("Lever", UnityEngine.Random.Range(.90f, 1f));
            pullLever = false;
        }


        if (isActive)
        {
            Debug.Log("Don't Click me Dumbass");
            isActive = false;
            //Randomize World
            randEvent = Random.Range(0, 2);
            //Generate World
            startEvent();

            

            //Pull Lever


        }
        if (!isActive)
        {
            if(eventOcean==true && canEnd == true)
            {
                FindObjectOfType<AudioManager>().PlaySound("Water", UnityEngine.Random.Range(.90f, 1f));
                FindObjectOfType<AudioManager>().SoundReset("Water");

                eventOcean = false;
                canEnd = false;
                Debug.Log("making water fall");
                FindObjectOfType<gameManager>().fallWater();
            }
            else if (eventCreepy == true && canEnd == true)
            {
                //FindObjectOfType<AudioManager>().PlaySound("Water", UnityEngine.Random.Range(.90f, 1f));
                //FindObjectOfType<AudioManager>().SoundReset("Water");
                Debug.Log("Resetting");
                randEvent = -1;
                eventCreepy = false;
                canEnd = false;
                startEvent();
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
                myLever.SetBool("pulled", false);
                spawnOcean();
                eventOcean = true;
            }
            else if (randEvent == 1)
            {
                myLever.SetBool("pulled", false);
                spawnCreepy();
            }
            else if (randEvent == -1)
            {
                myLever.SetBool("pulled", false);
                blackScreenFront.SetActive(true);
                resetCreepy();

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
            FindObjectOfType<AudioManager>().PlaySound("Water", UnityEngine.Random.Range(.90f, 1f));
            FindObjectOfType<AudioManager>().SoundReset("Water");
            FindObjectOfType<gameManager>().riseWater();
            yield return new WaitForSeconds(3);
            generateOcean();
        }
    }

    void generateOcean()
    {
        canEnd = true;
        Debug.Log("Ocean is created");
    }

    void spawnCreepy()
    {
        myArcade.SetBool("Creepy", true);
        blackScreen.SetActive(true);
        blackScreenFront.SetActive(true);

        //Initiate Build Up
        StartCoroutine(turnOnLights());

        IEnumerator turnOnLights()
        {

            yield return new WaitForSeconds(3);
            blackScreenFront.SetActive(false);
            foreach (GameObject enemy in eyeballs)
            {
                enemy.SetActive(true);
            }
            canEnd = true;
            eventCreepy = true;
            pullLever = true;
        }
    }

    void resetCreepy()
    {
        myArcade.SetBool("Creepy", false);
        blackScreen.SetActive(false);

        //Initiate Build Up
        StartCoroutine(turnOnLights2());

        IEnumerator turnOnLights2()
        {

            yield return new WaitForSeconds(3);
            blackScreenFront.SetActive(false);
            foreach (GameObject enemy in eyeballs)
            {
                enemy.SetActive(false);
            }

        }
        canEnd = true;
        eventCreepy = false;
        pullLever = true;
        isActive = true;
    }



}
