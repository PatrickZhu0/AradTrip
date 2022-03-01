using System;

namespace behaviac
{
	// Token: 0x0200484F RID: 18511
	public class LeafTask : BehaviorTask
	{
		// Token: 0x0601A9EC RID: 109036 RVA: 0x00550180 File Offset: 0x0054E580
		protected LeafTask()
		{
		}

		// Token: 0x0601A9ED RID: 109037 RVA: 0x00550188 File Offset: 0x0054E588
		public override void traverse(bool childFirst, NodeHandler_t handler, Agent pAgent, object user_data)
		{
			handler(this, pAgent, user_data);
		}
	}
}
