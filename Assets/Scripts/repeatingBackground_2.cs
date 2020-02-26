using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackground_2 : MonoBehaviour
{
    public GameObject myEnvironment_2;
    BoxCollider2D groundCollider;
    float groundHorizontalLength;
    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -(groundHorizontalLength*2 + 50))
        {
            RepositionBackground();
        }
    }
    void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2 ( groundHorizontalLength * 3f, 0);
        myEnvironment_2.transform.position = (Vector2)myEnvironment_2.transform.position + groundOffset;
    }
}
