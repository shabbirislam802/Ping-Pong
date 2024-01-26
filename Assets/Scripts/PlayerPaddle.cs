using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public float speed = 10f;
    public float minY = -3.5f;
    public float maxY = 3.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movePadddle();
    }

    private void movePadddle()
    {
        float movement = 0f;

        if (Input.GetKey(up))
        {
            movement += speed * Time.deltaTime;
        }
        if (Input.GetKey(down))
        {
            movement -= speed * Time.deltaTime;
        }

        float newY = Mathf.Clamp(transform.position.y + movement, minY, maxY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
