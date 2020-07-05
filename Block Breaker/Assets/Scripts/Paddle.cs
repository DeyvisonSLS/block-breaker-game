using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Paddle : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 screenBounds;
    private float paddleWidth;
    [SerializeField]
    private GameObject testObj;

    // Start is called before the first frame update
    void Start()
    {
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        paddleWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, transform.position.y, transform.position.z)).x;
        float minPos = Camera.main.ScreenToWorldPoint(new Vector3(0, transform.position.y, transform.position.z)).x;

        mousePosition = transform.position; // Preserves the y and z position
        mousePosition.x = Mathf.Clamp(mousePos.x, minPos + paddleWidth, maxPos - paddleWidth);

        // testObj.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, 1.0f));
        
        // mousePosition.x = Mathf.Clamp01(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        
        transform.position = mousePosition;
    }
}
