using UnityEngine;
using System.Collections;
public class hitcoin : MonoBehaviour
{
	private hitcoin playerInventoryDisplay;
	private bool carryingStar = false;
	void Start()
	{
		playerInventoryDisplay = GetComponent <
			hitcoin > ();
	}
	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag("coin"))
		{
			carryingStar = true;
			Destroy(hit.gameObject);
		}
	} 
}