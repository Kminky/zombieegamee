using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Renderer rend;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}