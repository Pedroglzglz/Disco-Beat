using UnityEngine;

public class CharactersAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0f;
        
        if (rb!= null)
        {
            speed = rb.velocity.magnitude;
        }
        else if (cc != null)
        {
            speed = new Vector3 (cc.velocity.x, 0, cc.velocity.z).magnitude;
        }
        animator.SetFloat ("Speed", speed);
    }
}
