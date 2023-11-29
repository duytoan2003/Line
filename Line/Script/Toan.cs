using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toan : MonoBehaviour
{
    //ScreenController screen;
    
    public bool check = false;
    Rigidbody2D rb;
    Animator dichuyen;
    Collider2D box;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dichuyen = GetComponent<Animator>();        
        box = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Drawer"))
        {    
            Debug.Log("1"); 
            dichuyen.SetTrigger("Fall");  
            dichuyen.SetTrigger("Fall2");  
            rb.AddForce(new Vector2(0.5f, 0.5f), ForceMode2D.Impulse);
            check = true;
            StartCoroutine(CountdownCoroutine());
            tag = "Untagged";     
        }        
    }
    private IEnumerator CountdownCoroutine()
    {
        int countdownTime = 3;

        while (countdownTime > 0)
        {
            Debug.Log(countdownTime);
            yield return new WaitForSeconds(1f); // Đợi 1 giây

            countdownTime--;
        }

        ScreenController.instance.NextLevel();
    }
    
}
