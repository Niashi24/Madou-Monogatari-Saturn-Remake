Shader "Custom/Quadratic Perspective Projection" {
    
    Properties {
        _MainTex("Base (RGB)", 2D) = "white" {}
    }
    
    SubShader {
        pass {
            CGPROGRAM
            uniform sampler2D _MainTex;
            float4 _MainTex_ST;
    
            #pragma vertex vert          
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct VertexData
            {
                float3 pos : POSITION;
                float3 uvq : TEXCOORD0; 
            };
    
            void vert(
                VertexData vtx,
                out float3 uvq : TEXCOORD0,
                out float4 posClip : SV_POSITION
            )
            {
                posClip = UnityObjectToClipPos(vtx.pos);
                
                uvq = vtx.uvq;
            }
    
            void frag(
                float3 uvq : TEXCOORD0,
                out float4 col : SV_Target
            )
            {
                col = tex2D(_MainTex, uvq.xy / uvq.z);
                if (col.a < 1) //this is bad. pls help
                    discard;
            }
    
            ENDCG
        }
    }
}