using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float playerVelocity = 100f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    private Quaternion startRotation;
    private Vector3 dir = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 slide = new Vector3(-8f, 0f, 0f);
    private bool isGrounded;

    private void Start()
    {
        this.startRotation = transform.rotation;
        var rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        this.transform.position += Vector3.forward * (this.speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Input.GetKeyDown("space"))
        {
            rb.velocity = Vector3.up * this.playerVelocity;
        }

        

        if (Input.GetKeyDown(KeyCode.LeftShift) && !this.isSliding)
        {
            StartCoroutine(this.SliderAnim());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Lose();
        }
    }

    private IEnumerator Fade()
    {
        var tickAmount = 10;
        var tickDuration = 0.01f;
        for (var i = 0; i < tickAmount; i++)
        {
            var t = 0f;
            var startRotation = transform.rotation;
            var endRotation = startRotation  * Quaternion.Euler(slide);
            

            while (t < 1)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
                t += tickDuration < 0 ? 1 : (Time.deltaTime / tickDuration);
                yield return new WaitForEndOfFrame();
            }

            yield return transform.rotation = endRotation;
        }
    }

    private bool isSliding = false;

    private IEnumerator SliderAnim()
    {
        isSliding = true;
        StartCoroutine(this.Fade());
        while (!isGrounded)
        {
            this.rb.velocity += new Vector3(0, -5, 0) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(.5f);
        this.transform.rotation = this.startRotation;
        yield return isSliding = false;
    }

    private void Lose()
    {
        SceneManager.LoadScene("main");
    }
}