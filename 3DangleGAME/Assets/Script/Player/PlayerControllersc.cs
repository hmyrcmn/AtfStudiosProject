using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllersc : MonoBehaviour
{
    private CharacterController controller;
    public float speed;
    public float maxSpeed;
    private Vector3 direction;

    public int desiredLane = 1;
    public float laneDistance;

    public float jumpForce;
    public float Gravity=-20;

   


    public bool isGrounded;
    // Declare the isGrounded variable
   //private bool isGrounded = false;
      // Yer kontrolü için kullanılacak nesne ve yer katmanı
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Animator animator;
    private bool isSliding = false;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(!PlayerManager.isGameStarted)   
            return;

        // hız arttırma
        if(speed<maxSpeed)    
            speed+=0.1f*Time.deltaTime;

        animator.SetBool("isGameStarted",true);

        //transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);

        controller.Move(direction * Time.fixedDeltaTime);
        direction.z = speed;
        
         isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
         print(controller.isGrounded);
         animator.SetBool("isGrounded",controller.isGrounded);

            if(controller.isGrounded){
                direction.y=-1;       
                //jumping 
                //Input.GetKeyDown(KeyCode.UpArrow)
                if(SwipeManager.swipeUp){
                    jump();
                }
            }else{
                direction.y +=Gravity*Time.deltaTime;

            }

            if(SwipeManager.swipeDown && !isSliding){
                StartCoroutine(Slide());
            }
            //Input.GetKeyDown(KeyCode.RightArrow
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        //Input.GetKeyDown(KeyCode.LeftArrow)
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
           // *  transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);
            
        // if have error about tarfffic block behave like is trigger open this code line
        // controller.center= controller.center;
        }
        else if(desiredLane == 1)
        {
            var temp= new Vector3(0.0f,transform.position.y,transform.position.z);
           // * transform.position = Vector3.Lerp(transform.position,temp,80*Time.deltaTime);
            
        // if have error about tarfffic block behave like is trigger open this code line
         //controller.center= controller.center;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
            // * transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);
            
        // if have error about tarfffic block behave like is trigger open this code line
         //controller.center= controller.center;
        }
            // added bug
        if(transform.position==targetPosition) {
            return;
        }
        Vector3 diff=targetPosition-transform.position;
        Vector3 moveDir=diff.normalized*25*Time.deltaTime;
        if(moveDir.sqrMagnitude<diff.sqrMagnitude)
            controller.Move(moveDir);
            else
            controller.Move(diff);



    }

    private void FixedUpdate()
    {
        if(!PlayerManager.isGameStarted)   
            return;
               //  controller.Move(direction * Time.fixedDeltaTime); 

    }

    void jump(){
        direction.y=jumpForce;        
    }

   private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obstacle")
        {
            print("game over ");
            FindObjectOfType<ses>().gameObject.transform.GetChild(2).gameObject.SetActive(true);
            PlayerManager.gameOver=true;

           
        }
    }

    
    
    private IEnumerator Slide()
    {
        
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center=new Vector3 (0,-0.5f,0);
        controller.height=1;
        

        yield return new WaitForSeconds(1.3f);
        controller.center=new Vector3 (0,0,0);
        controller.height=2;

        animator.SetBool("isSliding", false);
        
        isSliding = false;

    }


}
