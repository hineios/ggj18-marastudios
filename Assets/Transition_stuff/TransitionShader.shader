// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:6,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:4,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:7872,x:32782,y:32678,varname:node_7872,prsc:2|diff-4845-RGB,emission-4845-RGB,alpha-4965-OUT,clip-4965-OUT;n:type:ShaderForge.SFN_Tex2d,id:4845,x:32359,y:32630,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_4845,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0d19e39a1d654894889590fdadb03567,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7847,x:32025,y:32811,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_3771,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e958c6041cfe445e987c73751e8d4082,ntxv:0,isnm:False|UVIN-9565-OUT;n:type:ShaderForge.SFN_Panner,id:9356,x:31659,y:32722,varname:node_9356,prsc:2,spu:0,spv:0.1|UVIN-7898-UVOUT,DIST-358-TDB;n:type:ShaderForge.SFN_TexCoord,id:7898,x:31343,y:32668,varname:node_7898,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:358,x:31320,y:32812,varname:node_358,prsc:2;n:type:ShaderForge.SFN_Slider,id:4610,x:31780,y:33118,ptovrint:False,ptlb:Clipping,ptin:_Clipping,varname:node_4610,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:0.1;n:type:ShaderForge.SFN_Slider,id:6228,x:32263,y:32846,ptovrint:False,ptlb:Transp,ptin:_Transp,varname:node_6228,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:9565,x:31903,y:32618,varname:node_9565,prsc:2|A-3991-OUT,B-9356-UVOUT;n:type:ShaderForge.SFN_Vector2,id:3991,x:31592,y:32538,varname:node_3991,prsc:2,v1:2,v2:0.05;n:type:ShaderForge.SFN_Multiply,id:1181,x:32325,y:33251,varname:node_1181,prsc:2|A-7847-R,B-4610-OUT;n:type:ShaderForge.SFN_Add,id:6116,x:32308,y:32966,varname:node_6116,prsc:2|A-7847-R,B-4610-OUT;n:type:ShaderForge.SFN_OneMinus,id:574,x:32471,y:32966,varname:node_574,prsc:2|IN-6116-OUT;n:type:ShaderForge.SFN_Clamp01,id:4965,x:32609,y:32966,varname:node_4965,prsc:2|IN-574-OUT;proporder:4845-7847-4610-6228;pass:END;sub:END;*/

Shader "Custom/NewSurfaceShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Noise ("Noise", 2D) = "white" {}
        _Clipping ("Clipping", Range(0, 0.1)) = 0.1
        _Transp ("Transp", Range(0, 1)) = 1
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Clipping;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 normalDirection = i.normalDir;
                float4 node_358 = _Time;
                float2 node_9565 = (float2(2,0.05)*(i.uv0+node_358.b*float2(0,0.1)));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_9565, _Noise));
                float node_4965 = saturate((1.0 - (_Noise_var.r+_Clipping)));
                clip(node_4965 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = _MainTex_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = _MainTex_var.rgb;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                return fixed4(finalColor,node_4965);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
