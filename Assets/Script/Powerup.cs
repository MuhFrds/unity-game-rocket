using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;

    // update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.TripleShotActive();
            }
            Destroy(this.gameObject);
        }
    }
}
