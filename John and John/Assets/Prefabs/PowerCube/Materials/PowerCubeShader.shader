
Shader "Custom/PowerCubeShader" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _CubeColor ("Cube Color", Color) = (0.26,0.19,0.16,0.0)
      _BgColor ("Bg Color", Color) = (0.45703125,0.39453125,0.5390625,1.0)
      _HighlightPower ("Highlight Power", Range(0.5,8.0)) = 3.0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 viewDir;
      };
      sampler2D _MainTex;
      float4 _CubeColor;
      float4 _BgColor;
      float4 _TempColor;
      float _HighlightPower;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          //if(o.Albedo.rgb.b >= _BgColor.rgb.b)
          //{
          	_TempColor.rgb.r = _CubeColor.rgb.r * (o.Albedo.rgb.r) + _BgColor.rgb.r * (1 - o.Albedo.rgb.r);
          	_TempColor.rgb.g = _CubeColor.rgb.g * (o.Albedo.rgb.g) + _BgColor.rgb.g * (1 - o.Albedo.rgb.g);
          	_TempColor.rgb.b = _CubeColor.rgb.b * (o.Albedo.rgb.b) + _BgColor.rgb.b * (1 - o.Albedo.rgb.b);
            o.Albedo.rgb = _TempColor.rgb;
          //}
          half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
          o.Emission = _CubeColor.rgb * pow (rim, _HighlightPower);
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }
