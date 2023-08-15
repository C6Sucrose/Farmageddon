Shader "Custom/Clouds_Shader"
{
    Properties
    {
        _MainTex ("Color Texture", 2D) = "white" {}
        _DisplacementMap ("Displacement Map", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _RoughnessMap ("Roughness Map", 2D) = "white" {}
        _RenderMap ("Render Map", 2D) = "white" {}
        _AOMap ("AO Map", 2D) = "white" {}
    }
    
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;
        sampler2D _DisplacementMap;
        sampler2D _NormalMap;
        sampler2D _RoughnessMap;
        sampler2D _RenderMap;
        sampler2D _AOMap;
        
        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
            o.Displacement = tex2D(_DisplacementMap, IN.uv_MainTex).r;
            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex).rgb);
            o.Roughness = tex2D(_RoughnessMap, IN.uv_MainTex).r;
            o.Emission = tex2D(_RenderMap, IN.uv_MainTex).rgb;
            o.Occlusion = tex2D(_AOMap, IN.uv_MainTex).r;
        }
        
        ENDCG
    }
    
    FallBack "Diffuse"
}
