Shader "Realms/StencilWindow"
{   
    Properties {
        _SRef("Stencil Ref", Float) = 1
        [Enum(UnityEngine.Rendering.CompareFunction)] _SComp("Stencil Comp", Float) = 8
        [Enum(UnityEngine.Rendering.StencilOp)] _SOp ("Stencil Operation", Float) = 2
    }
    
    SubShader
    {
        
        ZWrite off
        ColorMask 0
        cull off
        Stencil
        {
            Ref [_SRef]
            Pass [_SOp]
            Comp [_SComp]  
        }
        Pass
        {
        
            }
        
        }
    }
