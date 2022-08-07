using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] Text scoretxt;
    int Counter= 0;
    [SerializeField] GameObject coinFx;
    public GameObject RollingSound;
    [SerializeField] AudioSource GameSfx;
    [SerializeField] AudioClip CoinCollection;
    [SerializeField] AudioClip Bomb;
    [SerializeField] AudioClip Death;
    public Animator CoinAnimation;
    [SerializeField] GameObject RespawnPanel;
    Rigidbody rb;
    [SerializeField] GameObject NextLvlPanel;
    public bool isControllsEnabled = true;
    public Player player;
    public bool isInAir= false;


    // Start is called before the first frame update
    void Start()
    {
        isInAir = false;
        NextLvlPanel.SetActive(false);
        rb = transform.GetComponent<Rigidbody>();
        scoretxt.text = Counter.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isInAir == true)
        {
            RollingSound.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickAble"))
        {
            Instantiate(coinFx, other.gameObject.transform.position, Quaternion.identity);
            ScoreIncrement();
            other.gameObject.SetActive(false);
            GameSfx.PlayOneShot(CoinCollection);
            
        }
        
        Debug.Log(Counter);
        scoretxt.text = Counter.ToString();
        if (other.gameObject.CompareTag("Bomb"))
        {
            
            
            other.gameObject.SetActive(false);
            GameSfx.PlayOneShot(Bomb);
            GameSfx.PlayOneShot(Death);
            RollingSound.SetActive(false);
            RespawnPanel.SetActive(true);
            StartCoroutine(ResetRigidBodyandDisable());
            OnDeath();

        }
        
        

    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            isControllsEnabled = false;
            OnLvlComplete();
        }
        if (collision.gameObject.CompareTag("FloorToMoveOn"))
        {
            Debug.Log("friendly floor enter");
            isInAir = false;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Collided With Floor");
            GameSfx.PlayOneShot(Death);
            RollingSound.SetActive(false);
            RespawnPanel.SetActive(true);
            StartCoroutine(ResetRigidBodyandDisable());
            OnDeath();
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloorToMoveOn"))
        {
            Debug.Log("friendly floor exit");
            isInAir = true;
        }
    }


    private void OnLvlComplete()
    {
        NextLvlPanel.SetActive(true);

    }
    public void OnNxtLvlBtnClicked()
    {
        SceneManager.LoadScene("LoadNextLvl");
    }
    public void OnRestartBtnClicked()
    {
        SceneManager.LoadScene("same_scene");
    }

    void OnDeath()
    {
        rb.drag = 100;
      
    }
    void ScoreIncrement()
    {
        Counter = Counter + 1;
        CoinAnimation.SetTrigger("IsCoinCollected");
    }
    IEnumerator ResetRigidBodyandDisable()
    {
        if(rb != null)
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            
        }
        else
        {
            rb = GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        yield return new WaitForFixedUpdate();
        gameObject.SetActive(false);

    }
   
}
