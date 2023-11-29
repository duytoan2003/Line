using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyButton : MonoBehaviour
{
    private bool isDeleting;
    public CircleDrawer circleDrawer;
    public LineDrawer lineDrawer;
    public bool isCheck = false;
    public bool isCheck1 = false;
  
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        if (isDeleting && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            RaycastHit2D hitt = Physics2D.Raycast(ray.origin, ray.direction);
            Line line = hitt.collider.GetComponent<Line>();
            Tron tron = hit.collider.GetComponent<Tron>();
            if (tron != null)
            {
                
                Collider2D[] colliders = tron.GetComponents<Collider2D>();
					foreach (Collider2D collider in colliders)
					{
						collider.enabled = false;
					}
					Rigidbody2D rb = tron.GetComponent<Rigidbody2D>();
					rb.AddForce(new Vector2(1.5f, 5.0f), ForceMode2D.Impulse);
					// Xóa đối tượng Line được chọn
					//Destroy(selectedLine.gameObject);
					tron = null;
                    isDeleting = false;
                    //Debug.Log("1");
                    isCheck1 = true;
                    
            }
            if (line != null)
            {
                
                Collider2D[] colliders = line.GetComponents<Collider2D>();
					foreach (Collider2D collider in colliders)
					{
						collider.enabled = false;
					}
					Rigidbody2D rb = line.GetComponent<Rigidbody2D>();
					rb.AddForce(new Vector2(1.5f, 5.0f), ForceMode2D.Impulse);
					// Xóa đối tượng Line được chọn
					//Destroy(selectedLine.gameObject);
					line = null;
                    isDeleting = false;
                    isCheck1 = true;
            }
        }
        if(isCheck){
        isCheck = false;
        circleDrawer.check(false);
        lineDrawer.check(false);
        }
        
        if(isCheck1&&Input.GetMouseButtonUp(0)){
            lineDrawer.check(true);
            circleDrawer.check(false);
            isCheck1 = false;
        }
    }

    public void OnButtonClick()
    {
        isDeleting = true;
        isCheck = true;
        Debug.Log(circleDrawer.draw);
    }
}
