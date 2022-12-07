using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float lengthImg;
    private float startPos;
    private float posY = 0.2f;
    [SerializeField] Camera mainCam;
    [SerializeField] float parallaxEffect;
    [SerializeField] bool autoScroll = false;

    void Start()
    {
        startPos = transform.position.x;
        lengthImg = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() {
        float temp = (mainCam.transform.position.x * (1 - parallaxEffect));
        float dist = (mainCam.transform.position.x * parallaxEffect);

        float desiredXPos = startPos + dist;

        if (autoScroll) {
            desiredXPos = transform.position.x - parallaxEffect;
        }

        // transform.position = new Vector2(desiredXPos, posY);
        transform.position = new Vector2(desiredXPos, transform.position.y);
        // transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + lengthImg) {
            startPos += lengthImg;
        } else if (temp < startPos - lengthImg) {
            startPos -= lengthImg;
        }

    }
}
