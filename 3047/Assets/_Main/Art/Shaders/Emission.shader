Shader "3047/Emission"
{
    Properties
    {
        _TintColor ("Tint Color", Color) = (1,1,1,1)
       _MainTex ("Albedo (RGB)", 2D) = "white" {}
       [HDR] _EmissionColor("Emission Color", Color) = (0,0,0)
       //_Glossiness ("Smoothness", Range(0,1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf Standard fullforwardshadows
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        
        fixed4 _TintColor;
        fixed4 _EmissionColor;
        //half _Glossiness;

        struct Input
        {
            float2 uv_MainTex;
        };


        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput/*SurfaceOutputStandard*/ o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _TintColor;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            o.Emission = c.rgb * tex2D(_MainTex, IN.uv_MainTex).a * _EmissionColor;
            //o.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
