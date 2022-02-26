# WowFovChanger
Modifies recognized World of Warcraft executables to change the field of view.

Aimed at private servers running old client versions. Only works on 32-bit clients right now. Recognizes the MoP 64-bit executable but won't actually fix anything.

If you have other clients and you can find the FoV offsets, you can modify WowFovChanger.dat so the program sees the new client.

Field of view calculation is a very rough approximation that I eyeballed. I found some geometry that looked about 90° away from the character, zoomed in, then adjusted until the camera barely spanned the angle. I then divided 90 by whatever internal value gave me that FoV.

Vanilla and Burning Crusade seem to have lower field of view for the same internal value (about a 41:1 ratio where later clients are about 50:1).

I assume my FoV calculation is way off for different aspect ratios, but I haven't bothered trying to figure that out yet.
