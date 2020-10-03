using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Vector2 normalizedMousePosition;
    public float currentAngle;
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalizedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, 
            Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normalizedMousePosition.y, normalizedMousePosition.x) * Mathf.Rad2Deg;

        currentAngle = (currentAngle + 405)%360;

        direction = (int)currentAngle/90;

        //var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.position = 
        //find direction from mouse to player then move sword to that of sword + direction
    }
}
