// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32877,y:32721,varname:node_3138,prsc:2|diff-4769-OUT,alpha-9144-OUT;n:type:ShaderForge.SFN_Tex2d,id:2309,x:32121,y:32822,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_2309,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bc5a4faccd0f1e5419d8818eefa1c670,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:993,x:32299,y:32967,ptovrint:False,ptlb:node_993,ptin:_node_993,varname:node_993,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e958c6041cfe445e987c73751e8d4082,ntxv:2,isnm:False|UVIN-2780-OUT;n:type:ShaderForge.SFN_Panner,id:3155,x:31927,y:33230,varname:node_3155,prsc:2,spu:0,spv:-0.1|UVIN-9695-UVOUT,DIST-3971-TDB;n:type:ShaderForge.SFN_TexCoord,id:9695,x:31611,y:33176,varname:node_9695,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3971,x:31588,y:33320,varname:node_3971,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2780,x:32113,y:33128,varname:node_2780,prsc:2|A-2455-OUT,B-3155-UVOUT;n:type:ShaderForge.SFN_Vector2,id:2455,x:31860,y:33046,varname:node_2455,prsc:2,v1:0,v2:1;n:type:ShaderForge.SFN_Add,id:4769,x:32629,y:32820,varname:node_4769,prsc:2|A-2309-RGB,B-993-RGB,C-7526-RGB;n:type:ShaderForge.SFN_Color,id:7526,x:32332,y:33141,ptovrint:False,ptlb:node_7526,ptin:_node_7526,varname:node_7526,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.01778762,c2:0.3455882,c3:0.06074085,c4:1;n:type:ShaderForge.SFN_Multiply,id:9144,x:32682,y:33033,varname:node_9144,prsc:2|A-2309-A,B-993-G,C-3617-OUT;n:type:ShaderForge.SFN_Slider,id:3617,x:32493,y:33257,ptovrint:False,ptlb:node_3617,ptin:_node_3617,varname:node_3617,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7781289,max:1;proporder:2309-993-7526-3617;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _node_993 ("node_993", 2D) = "black" {}
        _node_7526 ("node_7526", Color) = (0.01778762,0.3455882,0.06074085,1)
        _node_3617 ("node_3617", Range(0, 1)) = 0.7781289
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _node_993; uniform float4 _node_993_ST;
            uniform float4 _node_7526;
            uniform float _node_3617;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_3971 = _Time;
                float2 node_2780 = (float2(0,1)*(i.uv0+node_3971.b*float2(0,-0.1)));
                float4 _node_993_var = tex2D(_node_993,TRANSFORM_TEX(node_2780, _node_993));
                float3 diffuseColor = (_MainTex_var.rgb+_node_993_var.rgb+_node_7526.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor,(_MainTex_var.a*_node_993_var.g*_node_3617));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
