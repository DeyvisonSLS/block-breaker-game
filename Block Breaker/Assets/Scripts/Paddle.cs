using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paddle : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 screenBounds;
    private float paddleWidth;
    // [SerializeField]
    // private float screenUnits = 16;
    // [SerializeField]
    // private GameObject testObj;

    // Start is called before the first frame update
    void Start()
    {
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        paddleWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        // A position in the retangle width converted to world point
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Normalized coordinate position (0,0 (bottom-left) até 1,1 (top-right) = Total screen (widht or height) divided by the coordinate 
        // inside screen where the mouse is over) to World position (how is the maths to find world pos?)
        // Here is important to use ViewportToWorldPoint for when the screen is resized we can't get too fast, in that way we make it responsive.
        // But, what is the math behind it?
        // Vector2 mousePosInUnits = Camera.main.ViewportToWorldPoint(Input.mousePosition / Screen.width);


        float maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, transform.position.y, transform.position.z)).x;
        float minPos = Camera.main.ScreenToWorldPoint(new Vector3(0, transform.position.y, transform.position.z)).x;

        mousePosition = transform.position; // Preserves the y and z position
        mousePosition.x = Mathf.Clamp(mousePos.x, minPos + paddleWidth, maxPos - paddleWidth);

        // testObj.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, 1.0f));
        
        // mousePosition.x = Mathf.Clamp01(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        
        transform.position = mousePosition;
    }
}
