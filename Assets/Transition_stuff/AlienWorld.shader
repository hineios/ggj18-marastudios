// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:6,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:4,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:7872,x:32782,y:32678,varname:node_7872,prsc:2|emission-363-OUT,alpha-5698-A;n:type:ShaderForge.SFN_Tex2d,id:5698,x:32296,y:32721,ptovrint:False,ptlb:node_5698,ptin:_node_5698,varname:node_5698,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:68e062ccc7e9ae54db17c2c76c813f30,ntxv:0,isnm:False|UVIN-8292-OUT;n:type:ShaderForge.SFN_Lerp,id:8292,x:32063,y:32721,varname:node_8292,prsc:2|A-3428-UVOUT,B-8045-R,T-9127-OUT;n:type:ShaderForge.SFN_Slider,id:9127,x:31693,y:32914,ptovrint:False,ptlb:node_9127,ptin:_node_9127,varname:node_9127,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.01965822,max:0.1;n:type:ShaderForge.SFN_TexCoord,id:3428,x:31727,y:32553,varname:node_3428,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:8045,x:31757,y:32718,ptovrint:False,ptlb:node_8045,ptin:_node_8045,varname:node_8045,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fd9537ac95cc72f4b9cd6b669ad18e00,ntxv:0,isnm:False|UVIN-8419-UVOUT;n:type:ShaderForge.SFN_Panner,id:8419,x:31543,y:32718,varname:node_8419,prsc:2,spu:0.1,spv:1|UVIN-3319-OUT;n:type:ShaderForge.SFN_Time,id:658,x:31091,y:32888,varname:node_658,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:1169,x:31116,y:32633,varname:node_1169,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:3319,x:31351,y:32718,varname:node_3319,prsc:2|A-1169-UVOUT,B-658-T;n:type:ShaderForge.SFN_Color,id:2907,x:31943,y:33051,ptovrint:False,ptlb:node_2907,ptin:_node_2907,varname:node_2907,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.366,c2:0.747,c3:0.353,c4:1;n:type:ShaderForge.SFN_Multiply,id:363,x:32605,y:32720,varname:node_363,prsc:2|A-5698-RGB,B-1734-OUT;n:type:ShaderForge.SFN_Tex2d,id:2471,x:31772,y:33208,ptovrint:False,ptlb:node_2471,ptin:_node_2471,varname:node_2471,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6436-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1734,x:32310,y:33072,varname:node_1734,prsc:2|A-2907-RGB,B-2471-RGB;n:type:ShaderForge.SFN_Panner,id:6436,x:31580,y:33208,varname:node_6436,prsc:2,spu:0.1,spv:-0.5|UVIN-3103-OUT;n:type:ShaderForge.SFN_Time,id:3385,x:31128,y:33378,varname:node_3385,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:9214,x:31153,y:33123,varname:node_9214,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:3103,x:31388,y:33208,varname:node_3103,prsc:2|A-9214-UVOUT,B-3385-TSL;proporder:5698-9127-8045-2907-2471;pass:END;sub:END;*/

Shader "Custom/NewSurfaceShader" {
    Properties {
        _node_5698 ("node_5698", 2D) = "white" {}
        _node_9127 ("node_9127", Range(0, 0.1)) = 0.01965822
        _node_8045 ("node_8045", 2D) = "white" {}
        _node_2907 ("node_2907", Color) = (0.366,0.747,0.353,1)
        _node_2471 ("node_2471", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Overlay"
            "RenderType"="TransparentCutout"
            "PreviewType"="Plane"
        }
        LOD 8000
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZTest Always
            
            
            Stencil {
                Ref 128
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform sampler2D _node_5698; uniform float4 _node_5698_ST;
            uniform float _node_9127;
            uniform sampler2D _node_8045; uniform float4 _node_8045_ST;
            uniform float4 _node_2907;
            uniform sampler2D _node_2471; uniform float4 _node_2471_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_4536 = _Time;
                float4 node_658 = _Time;
                float2 node_8419 = ((i.uv0+node_658.g)+node_4536.g*float2(0.1,1));
                float4 _node_8045_var = tex2D(_node_8045,TRANSFORM_TEX(node_8419, _node_8045));
                float2 node_8292 = lerp(i.uv0,float2(_node_8045_var.r,_node_8045_var.r),_node_9127);
                float4 _node_5698_var = tex2D(_node_5698,TRANSFORM_TEX(node_8292, _node_5698));
                float4 node_3385 = _Time;
                float2 node_6436 = ((i.uv0+node_3385.r)+node_4536.g*float2(0.1,-0.5));
                float4 _node_2471_var = tex2D(_node_2471,TRANSFORM_TEX(node_6436, _node_2471));
                float3 emissive = (_node_5698_var.rgb*(_node_2907.rgb*_node_2471_var.rgb));
                float3 finalColor = emissive;
                return fixed4(finalColor,_node_5698_var.a);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
