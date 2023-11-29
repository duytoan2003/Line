using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{
    public GameObject circlePrefab;
    public LayerMask canDrawOverLayer;
    public LayerMask cantDrawOverLayer;
    Tron currentCircle;
    public float radius = 0.1f; // Bán kính ban đầu của hình tròn
	public float distance = 1f; // Tốc độ tăng bán kính
	Camera cam;
    public bool draw = false;
    //float doubleClickTimeThreshold = 0.3f; // Ngưỡng thời gian giữa hai lần nhấp chuột
	//float lastClickTime = 0f; // Thời điểm nhấp chuột cuối cùng
	//Tron selectedCircle = null;
    public bool checkk = false;
    bool isCircle;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)&&draw)
        {
            Begin();

        }
        else if(Input.GetMouseButton(0)&& currentCircle != null&&draw){
            Draw();
            }
        else if (Input.GetMouseButtonUp(0)  && currentCircle != null&&draw)
        {
            End();
            
        }
        //DeleteCircle();
    }
    void Begin(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 1f, cantDrawOverLayer);   
        // Tạo hình tròn mới
        RaycastHit2D hitt = Physics2D.Raycast(mousePosition, Vector2.zero, 1f, canDrawOverLayer);
		
        if(hitt)
        if(!hit)
        if(currentCircle==null)
        {
           
            GameObject projectileObject = Instantiate(circlePrefab, mousePosition, Quaternion.identity);
            currentCircle = projectileObject.GetComponent<Tron>();
            //isDrawing = true; // Bắt đầu vẽ
            currentCircle.UsePhysics ( false );    
        }
        
    }
    void Draw(){
             distance = Vector3.Distance(currentCircle.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //float radiusDelta = distance * scaleSpeed;
             //scaleSpeed += distance;
            
            // Tăng bán kính theo tốc độ và hướng (dương hoặc âm)
            //radius += radiusDelta;
            // Thay đổi kích thước của hình tròn
            radius = 0.25f*distance;
            currentCircle.transform.localScale = new Vector3(radius, radius, 1f);
            
            //currentCircle.transform.localScale = new Vector3(radius*2f, radius*2f, 1f);
    }
    void End(){
            {currentCircle.UsePhysics ( true );
            currentCircle = null;}
    }
   public void check(bool x){
    draw = x;
   }
   
    /*public void DeleteCircle(){
		if (Input.GetMouseButtonDown(0))
    	{
        	if (Time.time - lastClickTime <= doubleClickTimeThreshold)
        	{
           		 if (selectedCircle != null)
            	{
					Collider2D[] colliders = selectedCircle.GetComponents<Collider2D>();
					foreach (Collider2D collider in colliders)
					{
						collider.enabled = false;
					}
					Rigidbody2D rb = selectedCircle.GetComponent<Rigidbody2D>();
					rb.AddForce(new Vector2(1.5f, 5.0f), ForceMode2D.Impulse);
					// Xóa đối tượng Line được chọn
					//Destroy(selectedLine.gameObject);
					selectedCircle = null;
					Debug.Log("Circle deleted!");
            	}
            Debug.Log("Double-click detected!");
        	}
			else
        	{
				// Nhấp chuột lần đầu tiên

				// Lựa chọn đối tượng mới
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

				if (hit.collider != null)
				{
					Tron tron = hit.collider.GetComponent<Tron>();
					if (tron != null)
					{
                        
						// Gán đối tượng Line được chọn
						selectedCircle = tron;
					}
				}
        	}
        	lastClickTime = Time.time;
    	}
	}*/
}
