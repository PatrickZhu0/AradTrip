using System;

namespace behaviac
{
	// Token: 0x020030C5 RID: 12485
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3 : Condition
	{
		// Token: 0x06014A45 RID: 84549 RVA: 0x006373FE File Offset: 0x006357FE
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_wutouqishi_beiji_event_node3()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x06014A46 RID: 84550 RVA: 0x00637410 File Offset: 0x00635810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3B1 RID: 58289
		private EventType opl_p0;
	}
}
