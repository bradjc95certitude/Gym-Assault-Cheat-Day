﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    float movementFactor = 0; //0 for not moved, 1 for moved
    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        IncrementMovementFactor();
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }

    private void IncrementMovementFactor()
    {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWaveValue = Mathf.Sin(tau * cycles);
        movementFactor = rawSinWaveValue / 2f + 0.5f; //fix sin wave to yield between 0 and 1
    }
}
