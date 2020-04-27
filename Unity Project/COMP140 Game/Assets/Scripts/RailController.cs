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


    /// <summary>
    /// Sets the referenced rail to active or inactive
    /// </summary>
    /// <param name="active"></param>
    /// Is the rail on or off
    /// <param name="rail"></param>
    /// The ID of the rail changed
    /// <param name="direction"></param>
    /// The direction the rail is facing so it rotates the correct way,
    /// either 1 or -1
    private void transformRail(bool active, int rail, int direction)
    {
        if (active)
        {
            rails[rail].rotation = Quaternion.Euler(0, 26 * direction, 0);
        }

        if (!active)
        {
            rails[rail].rotation = Quaternion.Euler(0, 18 * direction, 0);
        }
    }


    /// <summary>
    /// Gets a 4 digit number from the controller and parses the information to set the rails
    /// </summary>
    public void setRails(string input)
    {
        if (input[1].ToString() == "1")
        {
            railOneActive = true;
        }

        else
        {
            railOneActive = false;
        }


        if (input[0].ToString() == "1")
        {
            railTwoActive = true;
        }

        else
        {
            railTwoActive = false;
        }


        if (input[3].ToString() == "1")
        {
            railThreeActive = true;
        }

        else
        {
            railThreeActive = false;
        }


        if (input[2].ToString() == "1")
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
