using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] AudioClip rocketBoost;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    //[SerializeField] ParticleSystem leftBooster;
    //[SerializeField] ParticleSystem rightBooster;
    //[SerializeField] ParticleSystem mainBooster;
    Rigidbody Myrigidbody;
    //AudioSource audioSource;


    void Start()
    {
        Myrigidbody = GetComponent<Rigidbody>();
        Myrigidbody.centerOfMass = Vector3.zero;
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()

    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }


    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartLeftRotation();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartRightRotation();
        }
        else
        {
            StopRotation();
        }
    }


    /// Methods are below

    private void StartThrusting()
    {


        Myrigidbody.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);

        /*
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketBoost);
        }
        
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
      */
    }
    private void StopThrusting()
    {
        //audioSource.Stop();
        //mainBooster.Stop();
    }


    private void StartRightRotation()
    {
        ApplyRotation(rotationThrust);
        /*if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
        }*/

    }

    private void StartLeftRotation()
    {
        ApplyRotation(-rotationThrust);
        /*if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }*/

    }
    private void StopRotation()
    {
        //rightBooster.Stop();
        //leftBooster.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        Myrigidbody.freezeRotation = true; // freezing rotation for manual rotation
        transform.Rotate(rotationThisFrame * Time.deltaTime * Vector3.back);
        Myrigidbody.freezeRotation = false; // unfreezing rotation for physics system
    }

}