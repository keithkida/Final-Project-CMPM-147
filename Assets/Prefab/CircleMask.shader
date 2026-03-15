Shader "UI/CircleMaskURP"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
        _Center ("Center", Vector) = (0.5, 0.5, 0.5, 0)
        _Radius ("Radius", Float) = 0.01
    
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "RenderPipeline"="UniversalPipeline" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float4 _Color;
            float2 _Center;
            float _Radius;

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                float2 aspect = float2(_ScreenParams.x / _ScreenParams.y, 1.0);
                float2 uv = (IN.uv - _Center) * aspect;
                float dist = length(uv);


                if (dist < _Radius)
                    return float4(0,0,0,0); // transparent hole

                return _Color; // black overlay
            }
            ENDHLSL
        }
    }
}
