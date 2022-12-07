using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionGround : MonoBehaviour
{
    [SerializeField] GameObject[] backgrounds;
    [SerializeField] string bgTag;
    float highestXPosition;
    float offsetValue;
    float newXPos;
    Vector3 newPosition;

    private void Awake() {
        backgrounds = GameObject.FindGameObjectsWithTag(bgTag);

        offsetValue = backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.x;

        highestXPosition = backgrounds[0].transform.position.x;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if(backgrounds[i].transform.position.x > highestXPosition)
                highestXPosition = backgrounds[i].transform.position.x;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(bgTag))
        {

            newXPos = highestXPosition + offsetValue;
            highestXPosition = newXPos;

            newPosition = collision.transform.position;
            newPosition.x = newXPos;
            collision.transform.position = newPosition;

        }

    }
}
