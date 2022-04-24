
Shader "Custom/StandardWet" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_WetMaskTex ("Wet Map", 2D) = "black" {}
		_WetTint("Wet Tint", Color) = (1,1,1,1)
		_WetSmoothness("Wet Smoothness", Range(0,1)) = 0.85
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _WetMaskTex;
		
		struct Input 
		{
			float2 uv_MainTex;
			float2 uv2_WetMaskTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		half _WetSmoothness;
		fixed4 _WetTint;
		
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			fixed4 baseAlbedo = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			fixed4 wetAlbedo = baseAlbedo * _WetTint;

			float2 uv2 = IN.uv2_WetMaskTex * unity_LightmapST.xy + unity_LightmapST.zw;
			half wetness = tex2D(_WetMaskTex, uv2).r;
			
			fixed4 c = lerp(baseAlbedo, wetAlbedo, wetness);

			o.Albedo = c;
			
			o.Metallic = _Metallic;
			o.Smoothness = min(1, _Glossiness + wetness * _WetSmoothness);
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
