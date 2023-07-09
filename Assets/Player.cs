using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D Rb;
    public AudioClip GrabClip;
    public AudioSource Sfx;

    public bool isHoldingItem = false; // if the player is holding an item
    public Item currentCollisionItem; // What Items the trigger sees
    public Item currentlyHolding; // What the player is holding
    [SerializeField]
    float movementSpeed = 5f;
    float mvtModifier;

    // Start is called before the first frame update
    void Start()
    {
        currentCollisionItem = null;
        mvtModifier = 1;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set velocity
        Vector2 inputDirection = new Vector2(horizontalInput, verticalInput);
        Rb.velocity = inputDirection * movementSpeed * mvtModifier;
        if (isHoldingItem && currentlyHolding != null)
        {
            Vector2 forceAngle = currentlyHolding.gameObject.transform.position - transform.position;
            // Force on held item is in the direction of movement
            currentlyHolding.gameObject.GetComponent<Rigidbody2D>().velocity = inputDirection * movementSpeed * mvtModifier;
        }

        // Pick up / drop item
        if (Input.GetKey(KeyCode.Space))
        {
            if (currentlyHolding == null && currentCollisionItem != null)
            {
                isHoldingItem = true;
                currentlyHolding = currentCollisionItem;
                mvtModifier = .5f;

                Sfx.clip = GrabClip;
                Sfx.volume = OptionsData.SfxVolume;
                Sfx.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isHoldingItem)
            {
                isHoldingItem = false;
                mvtModifier = 1;
                currentlyHolding = null;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("item") && !isHoldingItem)
        {
            //isCollidingWithItem = true;
            currentCollisionItem = collider.gameObject.GetComponent<Item>();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("item") && !isHoldingItem && !Input.GetKey(KeyCode.Space))
        {
            currentlyHolding = null;
            currentCollisionItem = null;
            isHoldingItem = false;
        }
    }
    public void WasSeen()
    {
        if (isHoldingItem)
        {
            StartCoroutine(Transition());
        }
    }
    IEnumerator Transition()
    {
        //GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = Resources.Load();
        //GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
