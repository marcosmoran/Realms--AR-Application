Shader "Portal/CubeMap Stencil"
{
    Properties
    {
        [NoScaleOffset] _Tex ("Cubemap   (HDR)", Cube) = "grey" {}
        [Enum(UnityEngine.Rendering.CompareFunction)] _Stencil("StencilOP", int) = 3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Cull front 
    Stencil
        {
            Ref 1
            Comp[_Stencil]
        }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 texcoord : TEXCOORD0;
            };

            samplerCUBE _Tex;
            half4 _Tex_HDR;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.vertex.xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
            half4 tex = texCUBE (_Tex, i.texcoord);
            half3 c = DecodeHDR (tex, _Tex_HDR);
            return half4(c, .5);
            }
            ENDCG
        }
    }
}
