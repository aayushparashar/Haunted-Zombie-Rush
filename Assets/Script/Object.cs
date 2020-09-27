using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
	[SerializeField] float speed = 5f;
    [SerializeField]  float resetPosition = 40.5f;
    [SerializeField] float startPosition = -37f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
		    if(transform.position.x > resetPosition){
			    transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
		    }

        }
		
        
    }
}
