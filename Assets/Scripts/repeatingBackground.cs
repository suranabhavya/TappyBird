using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingBackground : MonoBehaviour
{
    public GameObject myEnvironment;
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
        if(transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }
    void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2 ( groundHorizontalLength * 3f, 0);
        myEnvironment.transform.position = (Vector2)myEnvironment.transform.position + groundOffset;
    }
}
