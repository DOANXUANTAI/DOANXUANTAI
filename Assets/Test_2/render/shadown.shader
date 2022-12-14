Shader "Hidden/shadown"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TemptTex ("Tempt Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
       // Cull Off ZWrite Off ZTest Always

      
           Tags {


           "Queue" = "TranSparent+1"

           }
     



        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
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
            sampler2D _TemptTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) +tex2D(_TemptTex,i.uv);
                // just invert the colors
                col.a = 2.0f - col.r *1.5f - col.b * 0.5f;
              
                return fixed4(0,0,0,col.a);
            }
            ENDCG
        }
    }
}
