using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour

{
    public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	public LayerMask canDrawOverLayer;
	int cantDrawOverLayerIndex;
	[Space ( 30f )]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;
	Line currentLine;	
	Camera cam;
	public bool draw = true;
	
	void Start ( ) {
		cam = Camera.main;
		cantDrawOverLayerIndex = LayerMask.NameToLayer ( "CantDrawOver" );
		Time.timeScale = 1;
	}

	void Update ( ) {
		if ( Input.GetMouseButtonDown ( 0 ) &&draw)
			BeginDraw ( );

		if ( currentLine != null  &&draw)
			Draw ( );

		if ( Input.GetMouseButtonUp ( 0 ) &&draw)
			EndDraw ( );
		//DeleteLine();	
	}
	// Begin Draw ----------------------------------------------
	void BeginDraw ( ) {
		currentLine = Instantiate ( linePrefab, this.transform ).GetComponent <Line> ( );
		//Set line properties
		currentLine.UsePhysics ( false );
		currentLine.SetLineColor ( lineColor );
		currentLine.SetPointsMinDistance ( linePointsMinDistance );
		currentLine.SetLineWidth ( lineWidth );
	}
	// Draw ----------------------------------------------------
	
	void Draw ( ) {
		Vector2 mousePosition = cam.ScreenToWorldPoint ( Input.mousePosition );
		RaycastHit2D hitt = Physics2D.Raycast(mousePosition, Vector2.zero, 1f, canDrawOverLayer);
		if(!hitt)
		
        {Debug.Log("end");
			EndDraw ( );}
		else
			currentLine.AddPoint ( mousePosition );
	}
	// End Draw ------------------------------------------------
	void EndDraw ( ) {
		if ( currentLine != null ) {
			if ( currentLine.pointsCount < 2 ) {
				//If line has one point
				Destroy ( currentLine.gameObject );
			} else {
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;
                
				//Activate Physics on the line
				currentLine.UsePhysics ( true );

				currentLine = null;
				//selectedLine = null;
			}
			
		}
	}
	public void check(bool x){
    draw = x;
   }
   
	
}
