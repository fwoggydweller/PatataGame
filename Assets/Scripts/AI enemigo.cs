using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIenemigo : MonoBehaviour
{
    private System.Random random = new System.Random();
    Rigidbody2D rb;
    [SerializeField]
    Rigidbody2D player;
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int rnd = random.Next(0, 15);
        if (rnd == 9)
        {
            SacarDirección(out Vector2 dir);
            controller.SetAxis(dir);
        }
        else
        {
            controller.SetAxis(Vector2.zero);
        }
        StartCoroutine(ContadorCoroutine());
    }
    private void SacarDirección(out Vector2 dir)
    {
        dir = Vector2.zero;
        dir.x = player.position.x - rb.position.x;
        dir.y = player.position.y - rb.position.y;
        if (dir.x < 0)
        {
            dir.x = -1;
        }
        else if (dir.x > 0)
        {
            dir.x = 1;
        }
        if (dir.y < 0)
        {
            dir.y = -1;
        }
        else if (dir.y > 0)
        {
            dir.y = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("A");
        if (collision.rigidbody == player)
        {
            Destroy(rb.gameObject);
        }
    }
    IEnumerator ContadorCoroutine()
    {
        int tiempoRestante = 2;
        yield return new WaitForSeconds(tiempoRestante);
    }
}
