using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private int lastScreenWidth;
    private int lastScreenHeight;

    // Use this for initialization
    void Start()
    {
        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;
        UpdateScreenBounds();
    }

    void UpdateScreenBounds()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // half of the width
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; // half of the height
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
            UpdateScreenBounds();
        }

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;

        // Movement code here...
        float moveX = joystick.Horizontal + Input.GetAxis("Horizontal");
        float moveY = joystick.Vertical + Input.GetAxis("Vertical");
        Vector3 movement = speed * Time.deltaTime * new Vector3(moveX, moveY, 0);
        transform.position += movement;
    }
}
