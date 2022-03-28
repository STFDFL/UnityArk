Shader "Custom/PostEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {

                float a = 2.18;
                float b = 3.17;
                float c = a*b;
                float d = pow(a,c);




                fixed4 col = tex2D(_MainTex, i.uv);

                // Wavy movement
                // NOTE:
                // _Time[0] = seconds since start / 20
                // _Time[1] = seconds since start
                // _Time[2] = seconds since start * 2
                // _Time[3] = seconds since start * 3
                //col = tex2D(_MainTex, i.uv + float2(0, sin( i.vertex.x/50 + _Time[1]) /10 ));

                // Moved the image in the y axis
                //col = tex2D(_MainTex, i.uv + float2(0, 0.1));

                // Invert the colors
                //col.rgb = 1 - col.rgb;

                // Colors towards red
                //col.r = 1;

                return col;
            }
            ENDCG
        }
    }
}
