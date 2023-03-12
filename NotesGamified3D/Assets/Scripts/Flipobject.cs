using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipobject : MonoBehaviour
{
    [SerializeField] private float flipSpeed = 1.0f;
    private bool isFlipping = false;
    private float flipTime = 0.0f;
    private Quaternion startRotation;
    private Quaternion endRotation;
    
    void Start()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(0, 180, 0) * startRotation;
    }

    void Update()
    {
        if (isFlipping)
        {
            flipTime += Time.deltaTime * flipSpeed;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, flipTime);
            if (flipTime >= 1.0f)
            {
                isFlipping = false;
                flipTime = 0.0f;
                Quaternion temp = endRotation;
                endRotation = startRotation;
                startRotation = temp;
            }
        }
    }

    public void StartFlip()
    {
        if (!isFlipping)
        {
            isFlipping = true;
        }
    }
}

