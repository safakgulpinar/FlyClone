using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Rotation
    [SerializeField] private float rotationSpeed;
    bool dragging = false;
    Rigidbody rb;

    //ForwardMovement
    [SerializeField] private float fSpeed;
    [SerializeField] private float flySpeed;
    [SerializeField] private StackController stackController;

    [SerializeField] private Transform startPos1;
    [SerializeField] private Transform startPos2;
    private bool isFlying = false;
    [SerializeField] private float wingangle;
    [SerializeField] private float wingsspeed;
    [SerializeField] private float fuel = 100f;
    [Range(0.01f, 1f)] [SerializeField] private float eksifuel;
    [SerializeField] bool isPlaying ;
    [SerializeField] private Animator animController;
    [SerializeField] private Transform mainCam;
    private bool onfly = false;

    [SerializeField] private FlashImage _flashImage = null;
    [SerializeField] private Color _newColor = Color.white;

    [SerializeField] private Photo _photo;

    [SerializeField] private TextMeshProUGUI score;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animController = GetComponent<Animator>();
    }


    void OnMouseDrag()
    {
        dragging = true;
    }

    private void Update()
    {
        if(isFlying)
        {
            startPos1.rotation = Quaternion.Lerp(startPos1.rotation, Quaternion.Euler(startPos1.eulerAngles.x, startPos1.eulerAngles.y, wingangle), wingsspeed* Time.deltaTime);
            startPos2.rotation = Quaternion.Lerp(startPos2.rotation, Quaternion.Euler(startPos2.eulerAngles.x, startPos2.eulerAngles.y, -wingangle), wingsspeed * Time.deltaTime);
        }
        else
        {
            startPos1.rotation = Quaternion.Lerp(startPos1.rotation, Quaternion.Euler(startPos1.eulerAngles.x, startPos1.eulerAngles.y, 0f), wingsspeed * Time.deltaTime);
            startPos2.rotation = Quaternion.Lerp(startPos2.rotation, Quaternion.Euler(startPos2.eulerAngles.x, startPos2.eulerAngles.y, 0f), wingsspeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        

    }

    private void FixedUpdate()
    {

        if(isPlaying)
        {
            rb.velocity = (transform.forward * fSpeed) + Vector3.up * rb.velocity.y;
            animController.SetBool("isRun", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }
        }
        
        

        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;

            transform.RotateAround(transform.position, Vector3.up, x);

        }

        if(onfly == true)
        { 
            if (Input.GetKey(KeyCode.Space) && fuel >= 0)
            {
            animController.SetBool("isFly", true);
            fuel -= eksifuel;
            rb.AddForce(Vector3.up * 20f);
            rb.velocity = (transform.forward * flySpeed) + Vector3.up * rb.velocity.y;
            

            if (!isFlying) isFlying = true;
            StartCoroutine(stackController.RemoveLastOne());

            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
            isFlying = false;
            stackController.TimeReset();
            }
        }
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stack"))
        {
            stackController.AddList(other.gameObject);
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            onfly = true;
            _flashImage.StartFlash(.25f, .5f, _newColor);
            _photo.onPhoto();            
        }

        if(other.gameObject.CompareTag("Ground2"))
        {
            animController.SetBool("isSalsa", true);
            fSpeed = 0f;
        }
        
        if(other.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
        }


        if (other.gameObject.CompareTag("20x"))
        {
            animController.SetBool("isSalsa", true);            
            fSpeed = 0f;
            score.SetText("1600");
        }
        if (other.gameObject.CompareTag("10x"))
        {
            animController.SetBool("isSalsa", true);
            fSpeed = 0f;
            score.SetText("800");
        }
        if (other.gameObject.CompareTag("5x"))
        {
            animController.SetBool("isSalsa", true);
            fSpeed = 0f;
            score.SetText("400");
        }
        if (other.gameObject.CompareTag("1x"))
        {
            animController.SetBool("isSalsa", true);
            fSpeed = 0f;
            score.SetText("80");
        }
    }

    
}

