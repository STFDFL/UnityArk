using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour
{
    public Material material;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Color[] pixels = new Color[1920 * 1080];
        //for (int x = 0; x < 1920; x++)
        //{
        //    for (int y = 0; y < 1080; y++)
        //    {
        //        pixels[x * y * 1080].r = 1.18f * 2.17f;
        //    }
        //}

        Graphics.Blit(source, destination, material);
    }
}
