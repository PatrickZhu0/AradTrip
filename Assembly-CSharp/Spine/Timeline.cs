using System;

namespace Spine
{
	// Token: 0x02004987 RID: 18823
	public interface Timeline
	{
		// Token: 0x0601B08B RID: 110731
		void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha, MixPose pose, MixDirection direction);

		// Token: 0x170022C9 RID: 8905
		// (get) Token: 0x0601B08C RID: 110732
		int PropertyId { get; }
	}
}
