using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Paddle : MonoBehaviour
{
    #region FIELDS
    private Vector3 _mousePosition;
    private Vector2 _screenBounds;
    #endregion

    #region PROPERTIES
    public float PaddleExtents
    { 
        get
        {
            return transform.GetComponent<SpriteRenderer>().bounds.extents.x;;
        }
    }
    #endregion

    #region MONOBEHAVIOUR
    void Update()
    {
        ConstrainPaddle();
    }
    #endregion
    
    #region PUBLIC METHODS
    #endregion

    #region PRIVATE METHODS
    private void ConstrainPaddle()
    {
        // A position in the retangle width converted to world point
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Normalized coordinate position (0,0 (bottom-left) até 1,1 (top-right) = Total screen (widht or height) divided by the coordinate 
        // inside screen where the mouse is over) to World position (how is the maths to find world pos?)
        // Here is important to use ViewportToWorldPoint for when the screen is resized we can't get too fast, in that way we make it responsive.
        // But, what is the math behind it?
        // Vector2 mousePosInUnits = Camera.main.ViewportToWorldPoint(Input.mousePosition / Screen.width);
        Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, transform.position.y, transform.position.z));
        Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0, transform.position.y, transform.position.z));

        // Preserves the y and z position
        _mousePosition = transform.position;
        _mousePosition.x = Mathf.Clamp(mousePos.x, minPos.x + PaddleExtents, maxPos.x - PaddleExtents);

        // testObj.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, 1.0f));
        
        // mousePosition.x = Mathf.Clamp01(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        
        transform.position = _mousePosition;
    }
    #endregion
}
