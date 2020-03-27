using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour
{
    [SerializeField]
    private Transform[] rails = null;
    
    private bool railOneActive;
    private bool railTwoActive;
    private bool railThreeActive;
    private bool railFourActive;


    void Update()
    {
        //Manual Track control - Depricated

        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            railOneActive = !railOneActive;
            transformRail(railOneActive, 0, 1);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            railTwoActive = !railTwoActive;
            transformRail(railTwoActive, 1, -1);
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            railThreeActive = !railThreeActive;
            transformRail(railThreeActive, 2, 1);
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            railFourActive = !railFourActive;
            transformRail(railFourActive, 3, -1);
        }*/
    }

    private void transformRail(bool active, int rail, int direction)
    {
        if (active)
        {
            rails[rail].rotation = Quaternion.Euler(0, 30 * direction, 0);
        }

        if (!active)
        {
            rails[rail].rotation = Quaternion.Euler(0, 15 * direction, 0);
        }
    }

    public void setRails(string input)
    {
        if (input[0].ToString() == "1")
        {
            railOneActive = true;
        }

        else
        {
            railOneActive = false;
        }


        if (input[1].ToString() == "1")
        {
            railTwoActive = true;
        }

        else
        {
            railTwoActive = false;
        }


        if (input[2].ToString() == "1")
        {
            railThreeActive = true;
        }

        else
        {
            railThreeActive = false;
        }


        if (input[3].ToString() == "1")
        {
            railFourActive = true;
        }

        else
        {
            railFourActive = false;
        }

        transformRail(railOneActive, 0, 1);
        transformRail(railTwoActive, 1, -1);
        transformRail(railThreeActive, 2, 1);
        transformRail(railFourActive, 3, -1);
    }
}
