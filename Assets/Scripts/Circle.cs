using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    public float addSpeed = 10f;

    void OnEnable()
    {
        addSpeed = 0f;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            addSpeed += 40f;
        }
        transform.Rotate(new Vector3(0, 0, addSpeed * Time.deltaTime));
    }
}
