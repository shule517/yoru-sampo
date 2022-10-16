Shader "Hidden/NewImageEffectShader"
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

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float percent = (_Time*20 % 4)/4;

                float kr = 0.298912;
                float kg = 0.586611;
                float kb = 0.114478;

                fixed v = col.r * kr + col.g * kg + col.b * kb;
                //return fixed4(col.r, col.g, col.b, col.a);
                return fixed4(v*percent + col.r*(1/percent), v*percent + col.g*(1/percent), v*percent + col.b*(1/percent), col.a);

                //return fixed4(col.r, col.g, col.b, col.a);
            }
            ENDCG
        }
    }
}
