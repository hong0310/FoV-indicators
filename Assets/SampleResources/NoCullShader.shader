Shader "Custom/NoCullShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        // Disabling backface culling
        #pragma multi_compile _ CULL_OFF

        struct Input
        {
            float2 uv_MainTex;
        };

        half4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = _Color;
            o.Albedo = c.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
