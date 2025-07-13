#version 330 core
out vec4 FragColor;
in vec3 WorldPos;

uniform sampler2D equirectangularMap;

// {1/(2Pi), 1/Pi
const vec2 invAtan = vec2(0.1591, 0.3183);
// Just a basic linear maping from [0,2Pi] to [0,1] for U and [-Pi/2,Pi/2] to [0,1] for V.
vec2 SampleSphericalMap(vec3 v)
{
    // spherical to uv
    vec2 uv = vec2(atan(v.z, v.x), asin(v.y));
    uv *= invAtan;
    uv += 0.5;
    return uv;
}

void main()
{		
    // Mapping from cubemap to a sphere: normalize(WorldPos)
    // world pos is within [-1,1]^3
    vec2 uv = SampleSphericalMap(normalize(WorldPos));
    vec3 color = texture(equirectangularMap, uv).rgb;
    
    FragColor = vec4(color, 1.0);
}