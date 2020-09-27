using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class zombie : MonoBehaviour
{
	public float rockSpeed = 5f;
	public Vector3 bottomPosition;
	public Vector3 topPosition;
	[SerializeField] float speed = 5f;
	[SerializeField] float resetPosition;

    // Start is called before the first frame update
    void Start()
    {
		float position1 = Random.Range(bottomPosition.y, topPosition.y);
		float position2 = Random.Range(bottomPosition.y, topPosition.y);
		topPosition = position1 > position2 ? new Vector3(topPosition.x, position1, topPosition.y) : new Vector3(topPosition.x, position2, topPosition.y);
		bottomPosition = position1 > position2 ? new Vector3(topPosition.x, position2, topPosition.y) : new Vector3(topPosition.x, position1, topPosition.y);
		StartCoroutine(Move(bottomPosition));   
    }
	void Update()
	{
		if (GameManager.instance.PlayerActive && !GameManager.instance.GameOver)
        {
				transform.Translate(Vector3.right * Time.deltaTime * speed);
				if (transform.position.x > resetPosition)
				{
					gameObject.SetActive(false);
				}
		}
		
    }
    IEnumerator Move(Vector3 target){
		while(Mathf.Abs((target - transform.position).y) > 0.20f){
			Vector3 direction = target.y == topPosition.y ? Vector3.up: Vector3.down;
			transform.Translate(direction*Time.deltaTime* speed);
			yield return null;
		}
			yield return new WaitForSeconds(0.5f);
			Vector3 newTarget = target.y == topPosition.y ? bottomPosition: topPosition;
			StartCoroutine(Move(newTarget));
			
	}
}
