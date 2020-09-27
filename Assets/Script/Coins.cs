using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float resetPosition = 14f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x > resetPosition)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
