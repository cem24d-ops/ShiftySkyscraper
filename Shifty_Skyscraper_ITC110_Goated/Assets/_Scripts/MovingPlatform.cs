using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    private float directionX = -1.0f;
    private float directionY = -1.0f;
    private float startX = 0.0f;
    private float startY = 0.0f;
    public float distanceX = 0.0f;
    public float distanceY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.localPosition.y;
        startX = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        // changing from going right to left
        if ( (distanceX > 0 && transform.localPosition.x >= startX + distanceX) || (distanceX < 0 && transform.localPosition.x >= startX) )
        {
            directionX = -1.0f;
        }
        // changing from going left to right
        if ( (distanceX > 0 && transform.localPosition.x <= startX) || (distanceX < 0 && transform.localPosition.x <= startX + distanceX) )
        {
            directionX = 1.0f;
        }
        
        
        // Changing from going up to going down
        if ( (distanceY > 0 && transform.localPosition.y >= startY + distanceY) || (distanceY < 0 && transform.localPosition.y >= startY) )
        {
            directionY = -1.0f;
        }
        // Changing from going down to going up
        if ((distanceY > 0 && transform.localPosition.y <= startY) || (distanceY < 0 && transform.localPosition.y <= startY + distanceY))
        {
            directionY = 1.0f;
        }


        if (distanceX == 0)
            directionX = 0;
        
        if (distanceY == 0)
            directionY = 0;
        
        transform.Translate(new Vector3(directionX, directionY, 0) * moveSpeed * Time.deltaTime);
    }
}
