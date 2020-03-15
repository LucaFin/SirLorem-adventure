using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private Transform sirLoremTransform;
    private float velocity=5f;
    private bool isGrounded;
    public  Image life;

    void Start()
    {
        player = this.gameObject;
        sirLoremTransform = player.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life.fillAmount > 0)
        {
            bool attack = false;
            if (Input.GetKey("d"))
            {
                sirLoremTransform.rotation = new Quaternion(0, 0, 0, 0);
                sirLoremTransform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime * velocity);
                animator.SetBool("left", false);
            }
            else if (Input.GetKey("a"))
            {
                sirLoremTransform.rotation = new Quaternion(0, 180, 0, 0);
                sirLoremTransform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime * velocity);
                animator.SetBool("left", true);
            }
            if (Input.GetKey("e"))
            {
                attack = true;
            }
            if (Input.GetKey("space") && isGrounded)
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
                isGrounded = false;
            }
            animator.SetBool("Axe", attack);
        }
        else { animator.SetBool("dead", true); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Transform>().position.y<sirLoremTransform.position.y)
        isGrounded = true;
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            life.fillAmount = life.fillAmount - 0.25f;
        }
    }
}
