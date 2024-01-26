using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        InitBallSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitBallSpawnPosition()
    {
        Instantiate(ball, Vector3.zero, Quaternion.identity);
    }
}
