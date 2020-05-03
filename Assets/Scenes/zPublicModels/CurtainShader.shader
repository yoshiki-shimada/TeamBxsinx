Shader "Custom/CurtainShader"
{
	Properties
	{
		//_Color ("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	//_Glossiness ("Smoothness", Range(0,1)) = 0.5
	//_Metallic ("Metallic", Range(0,1)) = 0.0
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input
		{
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			float yamp = 0.01 * sin(_Time * 100 + v.vertex.x * 100);
			float xamp = 0.2 * sin(_Time * 20 + v.vertex.z * 100);
			v.vertex.xyz = float3(v.vertex.x + xamp, v.vertex.y + yamp, v.vertex.z);
		}

		void surf(Input IN, inout SurfaceOutput o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}
