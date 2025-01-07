using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    bool isBoosting = false;
    [SerializeField] float boostDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime 은 pc마다 초당 프레임 속도가 달라서 그걸 맞춰주기 위해서 사용함. 
        // (1초에 10프레임, 1초에 100프레임 나오는 경우 0.1s, 0.01s 을 각각 곱하면 똑같이 1의 결과가 나옴)
        float steerAmout = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmout);
        transform.Translate(0, moveAmount, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp" && !isBoosting)
        {
            Debug.Log("Boost !");
            moveSpeed = boostSpeed;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bumps !");
        moveSpeed = slowSpeed;
    }
}
