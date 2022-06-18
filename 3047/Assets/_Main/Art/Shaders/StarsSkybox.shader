Shader "3047/Skyboxes/StarsSkybox"
{
    Properties
    {
        [Header(Gradient)]
        [HDR]_ColorA ("Color A", Color) = (1,1,1,1)
        [HDR]_ColorB ("Color B", Color) = (1,1,1,1)
        _GradiantStrength ("Gradiant Strength", Range(0, 3)) = 0
        
        [Header(Stars)]
        _StarColor ("Star Color", Color) = (1,1,1,1)
        _StarTilingX ("StarTiling x", float) = 8
        _StarTilingY ("StarTiling y", float) = 4
        _Stars ("Stars", float) = 10
        _StarDensity ("Star Density", float) = 50
        //_MainTex ("Texture", 2D) = "white" {}
        
        [Header(Scrolling)]
        _ScrollXSpeed ("X Scroll Speed", Range(0,10)) = 2
        _ScrollYSpeed ("Y Scroll Speed", Range(0,10)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 worldPos : TEXCOORD1;
            };

            float4 _ColorA;
            float4 _ColorB;
            float _GradiantStrength;

            float4 _StarColor;
            float _StarTilingX;
            float _StarTilingY;
            float _Stars;
            float _StarDensity;

            fixed _ScrollXSpeed;
            fixed _ScrollYSpeed;
            
            //sampler2D _MainTex;
            //float4 _MainTex_ST;


            float2 TilingAndOffset(float2 uv, float2 tilling, float2 offset = float2(0,0))
            {

                return uv * tilling + offset;
            }

            inline float2 VoronoiNoiseRandomVector (float2 uv, float offset)
            {
                float2x2 m = float2x2(15.27, 47.63, 99.41, 89.98);
                uv = frac(sin(mul(uv, m)) * 46839.32);
                return float2(sin(uv.y*+offset)*0.5+0.5, cos(uv.x*offset)*0.5+0.5);
            }

            void Voronoi(float2 uv, float angle_offset, float cell_density, out float Out, out float cells)
            {
                float2 g = floor(uv * cell_density);
                float2 f = frac(uv * cell_density);
                float t = 8.0;
                float3 res = float3(8.0, 0.0, 0.0);

                for(int y=-1; y<=1; y++)
                {
                    for(int x=-1; x<=1; x++)
                    {
                        float2 lattice = float2(x,y);
                        float2 offset = VoronoiNoiseRandomVector(lattice + g, angle_offset);
                        float d = distance(lattice + offset, f);
                        if(d < res.x)
                        {
                            res = float3(d, offset.x, offset.y);
                            Out = res.x;
                            cells = res.y;
                        }
                    }
                }
            }
            
            float4 Remap(float4 In, float2 InMinMax, float2 OutMinMax)
            {
                return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
            }
            
            float4 Gradiant(float4 worldPos, float4 colorA, float4 colorB, float strength)
            {
                float4 i = Remap(normalize(worldPos).g, float2(-1,1), float2(0,1));
                
                return lerp(colorB,colorA, pow(i, strength));
            }

            float4 Stars(float4 worldPos, float2 starTiling, float stars, float starDencity, float4 color)
            {

                float2 tiling = TilingAndOffset(normalize(worldPos), starTiling);


                fixed2 scrolledUV = tiling;
                fixed xScrollValue = _ScrollXSpeed * _Time;
                fixed yScrollValue = _ScrollYSpeed * _Time;

                scrolledUV += fixed2(xScrollValue, yScrollValue);

                float voronoi;
                float cells;
                Voronoi(scrolledUV, 100, stars, voronoi, cells);

                float4 col = pow(1 - saturate(voronoi), starDencity) * color;
                
                return col;
            }
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col =
                    Gradiant(i.worldPos, _ColorA, _ColorB, _GradiantStrength) +
                        Stars(i.worldPos, float2(_StarTilingX, _StarTilingY), _Stars, _StarDensity, _StarColor);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
