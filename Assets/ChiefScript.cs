using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiefScript : MonoBehaviour {


    public bool toFloat;

    public float valuetoDiscount;

    private string direction = "Down";

    public float countdown;

    private float actualCountdown;

    // Use this for initialization
    void Start () {

        actualCountdown = countdown;
    }
	
	// Update is called once per frame
	void Update () {


        actualCountdown -= Time.deltaTime;

        if (actualCountdown >= 0)
        {
            if (direction == "Down")
            {
                this.transform.Translate(0.0f, -valuetoDiscount, 0.0f);

            }
            else if (direction == "Up")
            {
                this.transform.Translate(0.0f, valuetoDiscount, 0.0f);

            }
        }
        else {

            GetNextDir();
            actualCountdown = countdown; }

    }


   private void GetNextDir()
    {
        if (direction == "Down")
            direction = "Up";

        else if(direction == "Up")
        {
            direction = "Down";

        }
    }
}
