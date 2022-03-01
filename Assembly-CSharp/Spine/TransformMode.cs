using System;

namespace Spine
{
	// Token: 0x020049BD RID: 18877
	[Flags]
	public enum TransformMode
	{
		// Token: 0x04012F16 RID: 77590
		Normal = 0,
		// Token: 0x04012F17 RID: 77591
		OnlyTranslation = 7,
		// Token: 0x04012F18 RID: 77592
		NoRotationOrReflection = 1,
		// Token: 0x04012F19 RID: 77593
		NoScale = 2,
		// Token: 0x04012F1A RID: 77594
		NoScaleOrReflection = 6
	}
}
