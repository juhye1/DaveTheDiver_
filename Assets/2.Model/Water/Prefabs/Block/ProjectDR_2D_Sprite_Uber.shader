//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "ProjectDR/2D_Sprite_Uber" {
Properties {
_MainTex ("Main Tex", 2D) = "white" { }
[Toggle(_TEXTUREBLENDING)] _TEXTUREBLENDING ("Use Texture Blending", Float) = 0
[Toggle(_TEXTUREBLENDING_SINGLE_TILING)] _TEXTUREBLENDING_SINGLE_TILING ("Single Tiling", Float) = 0
_SubTex ("Sub Texture", 2D) = "black" { }
_SubTexTiling ("Sub Texture Tiling", Vector) = (1,1,0,0)
_SubTexColor ("SubTexColor", Color) = (0,0,0,0)
[Toggle(_LIGHTING)] _LIGHTING ("Use Lighting", Float) = 0
_SpecularColor ("Specular Color", Color) = (1,1,1,1)
_LightFactor ("Light factor", Float) = 1
_AmbientStrength ("Ambient Strength", Float) = 1
_LightThreshold ("Light Threshold", Float) = 10
[Toggle(_FIXEDNORMAL)] _FIXEDNORMAL ("Use Fixed Normal (2D)", Float) = 0
[Toggle(_DIFFUSEBRIGHT)] _DIFFUSEBRIGHT ("Use DiffuseBright", Float) = 0
_DiffuseBright ("Diffuse Bright", Color) = (1,1,1,1)
_Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
[Toggle(_TRANSPARENT)] _TRANSPARENT ("Use Transparent", Float) = 0
[Toggle(_HSL)] _HSL ("Use HSL", Float) = 0
_Hue ("Hue", Range(-1, 3)) = 1
_Saturation ("Saturation", Range(-1, 3)) = 1
_Lightness ("Lightness", Range(-1, 3)) = 1
[Toggle(_OVERLAYCOLOR)] _OVERLAYCOLOR ("Use Overlay Color", Float) = 0
_OverlayColor ("Overlay Color", Color) = (0,0,0,0)
[Toggle(_GLOW)] _GLOW ("Use Glow", Float) = 0
_GlowTex ("Glow Texture", 2D) = "black" { }
_GlowMaskTex ("Glow Mask Texture (RGBA)", 2D) = "black" { }
_GlowIntensity ("Glow Intensity", Float) = 0
[Toggle(_EMISSIONCOLOR)] _EMISSIONCOLOR ("Use Emission Color", Float) = 0
_EMColor ("Emission Color", Color) = (0,0,0,0)
[Toggle(_FRESNEL)] _FRESNEL ("Use Fresnel", Float) = 0
_FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
_FresnelPower ("Fresnel Power", Float) = 1
_FresnelStrength ("Fresnel Strength", Float) = 1
_FresnelClamp ("Fresnel Clamp", Float) = 1
[Toggle(_LAVA)] LAVA ("Use LAVA", Float) = 0
_LavaTex ("Lava", 2D) = "white" { }
_LavaNoiseTex ("Noise", 2D) = "white" { }
_LavaTile ("Lava Tile", Range(1, 8)) = 2
_LavaBright ("Lava Bright", Range(0.1, 5)) = 2
_LavaDarkOffset ("Lava Dark Offset", Range(0.01, 1)) = 0.1
_LavaFlowSpeed ("Lava Flow Speed", Range(0.01, 1)) = 0.01
_LavaFlowSpeed2 ("Lava Flow Speed2", Range(0.01, 1)) = 0.02
_NoiseTile ("Noise Tile", Range(1, 8)) = 2
_LavaMaskTex ("Mask (A)", 2D) = "white" { }
_LavaDirX ("Lava Dir X", Range(-1, 1)) = 0
_LavaDirY ("Lava Dir Y", Range(-1, 1)) = 1
[Toggle(_FOG)] _FOG ("Use Fog", Float) = 0
_FogAmplify ("Fog Amplify", Range(0, 10)) = 1
[Enum(Off,0,On,1)] _ZWrite ("ZWrite", Float) = 1
[Enum(UnityEngine.Rendering.CompareFunction)] _ZTestCompare ("ZTest", Float) = 4
[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlendMode ("__src", Float) = 5
[Enum(UnityEngine.Rendering.BlendMode)] _DstBlendMode ("__dst", Float) = 10
[Enum(UnityEngine.Rendering.CullMode)] _CullMode ("__cull", Float) = 2
}
SubShader {
 Tags { "QUEUE" = "Geometry+0" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Geometry" }
 Pass {
  Tags { "QUEUE" = "Geometry+0" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Geometry" }
  Blend Zero Zero, Zero Zero
  ZTest Off
  ZWrite Off
  Cull Off
  GpuProgramID 8917
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "ShadowCaster"
  Tags { "LIGHTMODE" = "SHADOWCASTER" "QUEUE" = "Geometry+0" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Geometry" }
  ColorMask 0 0
  Cull Off
  GpuProgramID 91521
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "DepthOnly"
  Tags { "LIGHTMODE" = "DepthOnly" "QUEUE" = "Geometry+0" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Geometry" }
  ColorMask 0 0
  Cull Off
  GpuProgramID 157036
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "DepthNormals"
  Tags { "LIGHTMODE" = "DepthNormals" "QUEUE" = "Geometry+0" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Geometry" }
  Cull Off
  GpuProgramID 252911
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Universal2D"
  Tags { "LIGHTMODE" = "Universal2D" "QUEUE" = "Geometry+0" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Geometry" }
  Blend Zero Zero, Zero Zero
  ZWrite Off
  Cull Off
  GpuProgramID 345936
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
}
SubShader {
 LOD 300
 Tags { "IGNOREPROJECTOR" = "true" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "ShaderModel" = "2.0" "UniversalMaterialType" = "Lit" }
 Pass {
  LOD 300
  Tags { "IGNOREPROJECTOR" = "true" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "ShaderModel" = "2.0" "UniversalMaterialType" = "Lit" }
  Blend Zero Zero, Zero Zero
  ZTest Off
  ZWrite Off
  Cull Off
  GpuProgramID 408879
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MAIN_LIGHT_SHADOWS_CASCADE" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_SHADOWS_SOFT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_FIXEDNORMAL" "_FOG" "_LIGHTING" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" }
"// shader disassembly not supported on DXBC"
}
SubProgram "d3d11 " {
Keywords { "_MAIN_LIGHT_SHADOWS" "_MULTI_FOG" "_UNITY_POSTFX_FOG" }
Local Keywords { "_DIFFUSEBRIGHT" "_EMISSIONCOLOR" "_FIXEDNORMAL" "_FOG" "_LIGHTING" "_OVERLAYCOLOR" "_TRANSPARENT" }
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "ShadowCaster"
  LOD 300
  Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "SHADOWCASTER" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "ShaderModel" = "2.0" "UniversalMaterialType" = "Lit" }
  ColorMask 0 0
  Cull Off
  GpuProgramID 513337
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "DepthOnly"
  LOD 300
  Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "DepthOnly" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "ShaderModel" = "2.0" "UniversalMaterialType" = "Lit" }
  ColorMask 0 0
  Cull Off
  GpuProgramID 537062
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "DepthNormals"
  LOD 300
  Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "DepthNormals" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "ShaderModel" = "2.0" "UniversalMaterialType" = "Lit" }
  Cull Off
  GpuProgramID 645478
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
 Pass {
  Name "Universal2D"
  LOD 300
  Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "Universal2D" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "ShaderModel" = "2.0" "UniversalMaterialType" = "Lit" }
  Blend Zero Zero, Zero Zero
  ZWrite Off
  Cull Off
  GpuProgramID 762212
Program "vp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
Program "fp" {
SubProgram "d3d11 " {
"// shader disassembly not supported on DXBC"
}
}
}
}
CustomEditor "Dave2DShaderGUI"
}