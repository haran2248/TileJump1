using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalOscillation : MonoBehaviour
{
    // Start is called before the first frame update
    public float amplitude = 0.5f;  // The amplitude of the oscillation
    public float frequency = 1f;    // The frequency of the oscillation

    private Vector3 startPos;       // The starting position of the object

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = startPos.x + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector2(x, transform.position.y);
    }
}
