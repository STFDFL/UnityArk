using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rtw 
{
	public class Painter : MonoBehaviour 
	{
        [SerializeField]
        int _canvasSize = 256;

        Texture2D _canvas;

        [SerializeField]
        int _brushSize = 1;

        [SerializeField]
        AnimationCurve _falloff;

        [SerializeField]
        string _targetTextureName = "_MainTex";

        Mesh mesh;
        
		void Start () 
		{
            _canvas = new Texture2D(_canvasSize, _canvasSize);
            Color[] colours = _canvas.GetPixels();
            for(int i = 0; i < colours.Length; i++ )
            {
                colours[i] = Color.black;
            }

            _canvas.SetPixels(colours);
            _canvas.Apply();
		}
		
		void Update () 
		{
            if(!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                return;
            }

            Paint();
        }

        void Paint()
        {
            List<Renderer> rends = new List<Renderer>();

            Color targetColour = Color.white;
            if (Input.GetMouseButton(1))
            {
                targetColour = Color.black;
            }
            
            for (int x = -_brushSize + 1; x < _brushSize; x++)
            {
                for (int y = -_brushSize + 1; y < _brushSize; y++)
                {
                    Vector3 offset = new Vector3(x, y, 0f);
                    float offsetLength = offset.magnitude;

                    // Consider only a circular shape around centre point
                    if (offsetLength >= _brushSize)
                    {
                        continue;
                    }

                    float falloffValue = _falloff.Evaluate(Mathf.Clamp(offsetLength / (float)_brushSize, 0f, 1f));
                    if (falloffValue == 0f)
                    {
                        continue;
                    }

                    RaycastHit hit;
                    if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition + offset), out hit))
                    {
                        continue;
                    }

                    Renderer rend = hit.transform.GetComponent<Renderer>();
                    if (rend == null)
                    {
                        continue;
                    }

                    if (!rends.Contains(rend))
                    {
                        rends.Add(rend);
                    }

                    Vector2 pixelLightmapUV = hit.lightmapCoord;
                    pixelLightmapUV.x *= _canvas.width;
                    pixelLightmapUV.y *= _canvas.height;

                    int pixelX = (int)pixelLightmapUV.x;
                    int pixelY = (int)pixelLightmapUV.y;

                    Color existingColour = _canvas.GetPixel(pixelX, pixelY);
                    Color updateColour = targetColour * falloffValue;

                    if( (targetColour.r > existingColour.r && updateColour.r > existingColour.r)
                    || (targetColour.r < existingColour.r && updateColour.r < existingColour.r))
                    {
                        _canvas.SetPixel(pixelX, pixelY, updateColour);
                    }
                }
            }

            _canvas.Apply();
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetTexture(_targetTextureName, _canvas);

            foreach (Renderer rend in rends)
            {
                rend.SetPropertyBlock(mpb);
            }
        }
	}
}