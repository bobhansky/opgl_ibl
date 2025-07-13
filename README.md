
# opengl image based lighting demo

![Demo](https://github.com/bobhansky/opgl_ibl/blob/main/images/knight.gif)


Model comes from 

https://www.cgtrader.com/free-3d-models/character/fantasy-character/fantasy-armor-d4ecf232-0d71-49eb-9941-b138680776a4

66432 triangle, FPS is in yellow


## Pipeline:

1. For diffuse effects. Sample the original cubemap color (hdr) at the center of this probe as radiance to approximate the irradiance from every direction (subject to sampling resoluting)
    using Riemann sum. Then calculate the diffuse contributions.

2. For specular effects. Create mipmap based on roughness (using Normal Distribution Function D, so here the whole Rendering equation contains D) for radiance (prefilter). Pre calculate BRDF as texture to look up by NdotV and roughness.

3. using these textures as approx. to solve for rendering eqn (specular term), and then add with (1) for global illumination.

![Demo](https://github.com/bobhansky/opgl_ibl/blob/main/images/sphere1.png)

![Demo](https://github.com/bobhansky/opgl_ibl/blob/main/images/sphere2.png)



Run on Windows 11, Intel Core i7 12700h, Nvidia RTX 3060 laptop
