using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public float addSpeed;
    public static int score;


    void OnEnable()
    {
        addSpeed = 0f;
        score = 0;
    }

    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            addSpeed += 40f;
            score++;
        }
        transform.Rotate(new Vector3(0, 0, addSpeed * Time.deltaTime));
    }
}
