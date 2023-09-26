using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    private CharacterController characterController;

    //walltrap
    private float timer = 0.0f;
    bool hitTrap = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null)
        {
            if (body.gameObject.tag == "Spikes")
            {
                Die();
            }
            /*if (body.gameObject.tag == "WallTrap")
            {
                timer += Time.deltaTime;
                if (timer > 0.2)
                {
                    body.gameObject.GetComponent<Animator>().Play("WallTrapAnimation");
                    timer = 0;
                }
            }*/
        }
    }
    /*private void OnCollisionExit(Collision collision)
    {
        timer = 0;
    }*/

    private void Die()
    {
        Restart();
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
