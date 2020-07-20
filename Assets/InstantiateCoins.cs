using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class InstantiateCoins : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(100f, 0f, 0f) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
