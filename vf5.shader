// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/vf5"
{
    Properties{
        _R("R",range(0,5))=1
    }
   SubShader
    {
        pass{
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag

        #include "unitycg.cginc"
        float dis;
        float r;
        float _R;

        struct v2f{
            float4 pos: POSITION;
            float4 color:COLOR;
        };

        v2f vert (appdata_base v)
        {
            float2 xy=v.vertex.xz;
            float d = _R-length(xy);

            d = d<0?0:d;
            float height =1;

            float4 uppos=float4(v.vertex.x,height*d,v.vertex.z,v.vertex.w);

        
            v2f o;
            
            //投影
            o.pos=UnityObjectToClipPos(uppos);

            o.color=fixed4(uppos.y,uppos.y,uppos.y,1);
            //屏幕分量
            // float x= o.pos.x / o.pos.w;
            // // float y= o.pos.y / o.pos.w;
            // if(x>dis&&x<dis+r)
            // {
            //     o.color=fixed4(1,1,1,1);

            // }
            // else{
            //     o.color=fixed4(1,1,1,1);
            // }
            // if(v.vertex.x>0)
            // {
            //     //颜色变化随时间
            //     o.color=fixed4(_SinTime.w/2 +0.5,_CosTime.w/2 +0.5, _SinTime.y/2+0.5,1);
            // }
            // else
            // {
            //     o.color=fixed4(1,1,0,1);
            // }

            // float4 wpos=mul(unity_ObjectToWorld,v.vertex);

            // if(wpos.x>0)
            // {
            //     o.color=fixed4(1,0,0,1);
            // }
            // else{
            //     o.color=fixed4(1,1,0,1);
            // }

            
            return o;
        }

        float4 frag (v2f IN):COLOR
        {
            return IN.color;
        }
        
        ENDCG
        }

       
    }
}
