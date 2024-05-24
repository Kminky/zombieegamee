using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 150f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
