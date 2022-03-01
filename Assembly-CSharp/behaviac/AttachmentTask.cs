using System;

namespace behaviac
{
	// Token: 0x0200484E RID: 18510
	public class AttachmentTask : BehaviorTask
	{
		// Token: 0x0601A9EA RID: 109034 RVA: 0x00838A94 File Offset: 0x00836E94
		protected AttachmentTask()
		{
		}

		// Token: 0x0601A9EB RID: 109035 RVA: 0x00838A9C File Offset: 0x00836E9C
		public override void traverse(bool childFirst, NodeHandler_t handler, Agent pAgent, object user_data)
		{
			handler(this, pAgent, user_data);
		}
	}
}
