#if OPENGL
    #define SV_POSITION POSITION
    #define VS_SHADERMODEL vs_3_0
    #define PS_SHADERMODEL ps_3_0
#else
    #define VS_SHADERMODEL vs_4_0_level_9_1
    #define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
sampler s0;
float t;
float widthToHeight;

sampler2D SpriteTextureSampler = sampler_state
{
    Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};


float random(float2 p)
{
    return frac(cos(dot(p, float2(23.14069263277926, 2.665144142690225))) * 12345.6789);
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float3 one = float3(0, 50, 150) / 255.;
    float3 two = float3(0, 0, 150) / 255.;
    float3 three = float3(0, 50, 200) / 255.;
    float3 four = float3(0, 150, 255) / 255.;
    
    
    float2 uv = input.TextureCoordinates;
    uv.x *= widthToHeight;
    uv.x -= t * 2.0;
    uv *= 100.;
    float2 ipos = floor(uv);
    
    float randVal = random(ipos);
    float3 color;
    if (randVal > .75)
        color = one;
    else if (randVal > .5)
        color = two;
    else if (randVal > .25)
        color = three;
    else
        color = four;
    

    return float4(color, 1);
    
    /*float4 color = tex2D(s0, input.TextureCoordinates);
    return color;*/
}

technique SpriteDrawing
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};