// Marmoset Skyshop
// Copyright 2013 Marmoset LLC
// http://marmoset.co

Shader "Marmoset/Transparent/Cutout/Bumped Diffuse IBL" {
	Properties {
		_Color   ("Diffuse Color", Color) = (1,1,1,1)
		_Cutoff  ("Alpha Cutoff", Range (0,1)) = 0.5
		_MainTex ("Diffuse(RGB) Alpha(A)", 2D) = "white" {}
		_BumpMap ("Normalmap", 2D) 	= "bump" {}
		//slots for custom lighting cubemaps
		_DiffCubeIBL ("Custom Diffuse Cube", Cube) = "black" {}
		_SpecCubeIBL ("Custom Specular Cube", Cube) = "black" {}
	}
	
	SubShader {
		Tags {
			"Queue"="AlphaTest"
			"IgnoreProjector"="True"
			"RenderType"="TransparentCutout"
		}
		LOD 350
		//diffuse LOD 200
		//diffuse-spec LOD 250
		//bumped-diffuse, spec 350
		//bumped-spec 400
		
		//mac stuff
		CGPROGRAM
		#ifdef SHADER_API_OPENGL	
			#pragma glsl
		#endif
		
		#pragma target 3.0
		#pragma exclude_renderers d3d11_9x
		#pragma surface MarmosetSurf MarmosetDirect alphatest:_Cutoff fullforwardshadows
		//gamma-correct sampling permutations
		#pragma multi_compile MARMO_LINEAR MARMO_GAMMA

		#define MARMO_HQ
		#define MARMO_SKY_ROTATION
		#define MARMO_DIFFUSE_IBL
		//#define MARMO_SPECULAR_IBL
		#define MARMO_DIFFUSE_DIRECT
		//#define MARMO_SPECULAR_DIRECT
		#define MARMO_NORMALMAP
		//#define MARMO_MIP_GLOSS
		//#define MARMO_GLOW
		//#define MARMO_PREMULT_ALPHA
		#define MARMO_ALPHA
		 
		#include "../../MarmosetInput.cginc"
		#include "../../MarmosetCore.cginc" 
		#include "../../MarmosetDirect.cginc"
		#include "../../MarmosetSurf.cginc"

		ENDCG
	}
	
	FallBack "Transparent/Cutout/Bumped Diffuse"
}
