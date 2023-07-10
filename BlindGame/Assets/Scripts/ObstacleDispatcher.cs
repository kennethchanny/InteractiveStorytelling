using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDispatcher : MonoBehaviour
{
    private int eventNumber = 0;
    public AudioListPlay soundref2d;
    void Start()
    {
        EventManager.current.onObstacleTriggered += TriggerNextEvent;
        CallObstacles();
    }

    void Update()
    {
    }

    void TriggerNextEvent()
    {
        eventNumber++;
        CallObstacles();
    }

    void CallObstacles()
    {
        switch (eventNumber)

        {
            //Rope Snap, falling,
            case 0:
                {
                    soundref2d.PlayAudio(1); //Rope Snap
                    soundref2d.PlayAudio(0); //Rope Fall
                    soundref2d.PlayAudio(2); //Rock Impact
                }
                break;
            case 1:
                {
                    soundref2d.PlayAudio(3); //Placeholder

                }
                break;
            case 2:
                {

                }
                break;
            case 3:
                {

                }
                break;
            case 4:
                {

                }
                break;
            default:
                {
                    Debug.Log("NO MORE EVENTS");

                }
                break;

        }

    }

}
