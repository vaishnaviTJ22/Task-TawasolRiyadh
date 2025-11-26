Shader "Custom/URP/NeonGlow"
{
    Properties
    {
        [Header(Base Settings)]
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
        
        [Header(Glow Settings)]
        _GlowColor ("Glow Color", Color) = (0, 1, 1, 1)
        _GlowIntensity ("Glow Intensity", Range(0, 10)) = 2
        _FresnelPower ("Fresnel Power", Range(0.1, 10)) = 3
        _FresnelScale ("Fresnel Scale", Range(0, 1)) = 1
        
        [Header(Pulse Settings)]
        _PulseSpeed ("Pulse Speed", Range(0, 10)) = 1
        _PulseMin ("Pulse Min", Range(0, 1)) = 0.5
        _PulseMax ("Pulse Max", Range(0, 2)) = 1.5
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque" 
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry"
        }
        
        LOD 100

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float3 viewDirWS : TEXCOORD2;
                float3 positionWS : TEXCOORD3;
                float fogFactor : TEXCOORD4;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _BaseColor;
                float4 _GlowColor;
                float _GlowIntensity;
                float _FresnelPower;
                float _FresnelScale;
                float _PulseSpeed;
                float _PulseMin;
                float _PulseMax;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);
                VertexNormalInputs normalInput = GetVertexNormalInputs(input.normalOS);

                output.positionCS = vertexInput.positionCS;
                output.positionWS = vertexInput.positionWS;
                output.normalWS = normalInput.normalWS;
                output.viewDirWS = GetWorldSpaceViewDir(vertexInput.positionWS);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.fogFactor = ComputeFogFactor(vertexInput.positionCS.z);

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                
                float3 normalWS = normalize(input.normalWS);
                float3 viewDirWS = normalize(input.viewDirWS);
                
                float fresnel = pow(1.0 - saturate(dot(normalWS, viewDirWS)), _FresnelPower);
                fresnel *= _FresnelScale;
                
                float pulse = lerp(_PulseMin, _PulseMax, (sin(_Time.y * _PulseSpeed) + 1.0) * 0.5);
                
                float3 glow = _GlowColor.rgb * fresnel * _GlowIntensity * pulse;
                
                float3 baseColor = _BaseColor.rgb * texColor.rgb;
                
                Light mainLight = GetMainLight();
                float3 lighting = mainLight.color * saturate(dot(normalWS, mainLight.direction));
                
                float3 finalColor = baseColor * lighting + glow;
                
                finalColor = MixFog(finalColor, input.fogFactor);

                return float4(finalColor, _BaseColor.a * texColor.a);
            }
            ENDHLSL
        }
        
        Pass
        {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" }

            ZWrite On
            ZTest LEqual
            ColorMask 0

            HLSLPROGRAM
            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/LitInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
            ENDHLSL
        }
    }

    FallBack "Hidden/Universal Render Pipeline/FallbackError"
}
