Shader "Unlit/Visible"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CullColor ("Cull Color", Color) = (0,0,0,0)
        _VisibleColor ("Visible Color", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        LOD 100
        
        Pass
        {
            
            Cull Off
            ZWrite Off
            ZTest Always
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float4 _CullColor; 

             v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _CullColor;
            }

            ENDCG
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
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

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float4 _VisibleColor;

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                
                return _VisibleColor;
            }
            ENDCG
        }
    }
}
