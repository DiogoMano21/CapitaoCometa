using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float lengthX, lengthY, startposX, startposY;
    public GameObject cam;
    public float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void checkRightBG()
    {
        float tempX = cam.transform.position.x * (1 - parallaxEffect) + 2f;
        float distX = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startposX + distX, transform.position.y, transform.position.z);

        if (tempX > startposX + lengthX)
        {
            startposX += lengthX;
        }
        else
        {
            if (tempX < startposX - lengthX)
            {
                startposX -= lengthX;
            }
        }
    }

    void checkLeftBG()
    {
        float tempY = cam.transform.position.y * (1 - parallaxEffect);
        float distY = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startposY + distY, transform.position.z);

        if (tempY > startposY + lengthY)
        {
            startposY += lengthY;
        }
        else
        {
            if (tempY < startposY - lengthY)
            {
                startposY -= lengthY;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkRightBG();
        checkLeftBG();
    }
}
