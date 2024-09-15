using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBoundaries : MonoBehaviour
{
    public Camera _mainCamBoundaries; // Convert screen space to world space

    public Transform mouseSprite; // The empty GameObject that follows the mouse
    public Transform boundaryOrigin; // The empty GameObject to define the boundary origin

    public Vector2 _boundarySize; // Size of the boundary area in world space

    private Vector2 _boundaryMin;
    private Vector2 _boundaryMax;

    void Start()
    {
        
        Cursor.visible = false; // Activate and Deactivate de visibility of the cursor for Testing
        UpdateBoundaries();
    }

    void Update()
    {
        
        Vector3 mouseScreenPosition = Input.mousePosition; // Get the current mouse position in screen space
        mouseScreenPosition.z = Mathf.Abs(_mainCamBoundaries.transform.position.z - mouseSprite.position.z);

        
        Vector3 worldMousePos = _mainCamBoundaries.ScreenToWorldPoint(mouseScreenPosition); // Convert the mouse position from screen space to world space
        worldMousePos.z = 0; // Stays in 2D view

        
        worldMousePos.x = Mathf.Clamp(worldMousePos.x, _boundaryMin.x, _boundaryMax.x); // Clamp the position within the defined boundaries
        worldMousePos.y = Mathf.Clamp(worldMousePos.y, _boundaryMin.y, _boundaryMax.y);

        
        mouseSprite.position = worldMousePos; // Update the centerObject position
    }

    void UpdateBoundaries() // Calculate min and max boundaries based on the boundaryOrigin and size
    {
        
        _boundaryMin = (Vector2)boundaryOrigin.position - (_boundarySize / 2);
        _boundaryMax = (Vector2)boundaryOrigin.position + (_boundarySize / 2);
    }
}
