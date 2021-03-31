using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    mpus KomponenGerak;
    // Start is called before the first frame update
    void Start()
    {
        KomponenGerak = GameObject.Find("kocheng").GetComponent<mpus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D ndemok){
        if(ndemok.transform.tag == "player"){
            KomponenGerak.coin++;
            Destroy(gameObject);
        }
    }
}
