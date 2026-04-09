using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float baseJumpForce = 7f;
    [SerializeField]private Transform raycastTransformer;
    [SerializeField]private ParticleSystem particle;
    [SerializeField]private Animator PlayerAnimation;
    public float triggerCounter;
    [SerializeField]private GameLoop gameLoop;
    private bool ignoreCollision;
    [SerializeField]private UiManager uiManager;
    [SerializeField]private GameData gameData;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        
    }
    
    private void OnCollisionEnter(Collision other) {
        if(ignoreCollision){
            return;
        }
        else if(other.transform.CompareTag("Platform"))
        {
            rb.linearVelocity = Vector3.zero;
            float jumpForce = gameData != null ? gameData.GetJumpForce(baseJumpForce) : baseJumpForce;
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            ignoreCollision = true;
            Invoke(nameof(ResetCollision),0.2f);
        }
        else if(other.transform.CompareTag("obstacle"))
        {
            DieInObstacle();
        }
        else if(other.transform.CompareTag("Finish"))
        {
            gameLoop.GameWin();
            uiManager.gameWin();
        }
        particle.Play();
    }
    private void OnTriggerEnter(Collider other) {
        triggerCounter += 0.9f;
        print(triggerCounter);
        uiManager.SliderValue(triggerCounter / 2);
    }
    private void ResetCollision(){
        ignoreCollision = false;
    }
    
    public void DieInObstacle()
    {
        PlayerAnimation.SetBool("dead",true);
        rb.isKinematic = true;
        gameLoop.DieBall();
        uiManager.Die();
    }
    public void Restart()
    {
        PlayerAnimation.SetBool("dead",false);
        triggerCounter = 0;
    }
  
}
