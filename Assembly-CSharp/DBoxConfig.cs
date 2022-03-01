using System;

// Token: 0x020041D1 RID: 16849
public class DBoxConfig
{
	// Token: 0x04010BB4 RID: 68532
	public static bool b2D = true;

	// Token: 0x04010BB5 RID: 68533
	public static readonly VFactor angle = VFactor.pi * 20L / 180L;

	// Token: 0x04010BB6 RID: 68534
	public static readonly VFactor fSinA = IntMath.sin(DBoxConfig.angle.nom, DBoxConfig.angle.den);

	// Token: 0x04010BB7 RID: 68535
	public static readonly VFactor fCosA = IntMath.cos(DBoxConfig.angle.nom, DBoxConfig.angle.den);
}
