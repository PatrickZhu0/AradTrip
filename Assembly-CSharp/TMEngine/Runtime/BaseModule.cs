using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046F4 RID: 18164
	public abstract class BaseModule
	{
		// Token: 0x170021CF RID: 8655
		// (get) Token: 0x0601A0CC RID: 106700
		internal abstract int Priority { get; }

		// Token: 0x0601A0CD RID: 106701
		internal abstract void Update(float elapseSeconds, float realElapseSeconds);

		// Token: 0x0601A0CE RID: 106702
		internal abstract void Shutdown();
	}
}
