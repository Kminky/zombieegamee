using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public float crosshairScale = 1;

    private void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairTexture.width / 2) * crosshairScale;
        float yMin = (Screen.height / 2) - (crosshairTexture.height / 2) * crosshairScale;
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
    }
}