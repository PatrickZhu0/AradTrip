using System;

namespace behaviac
{
	// Token: 0x020030B1 RID: 12465
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node5 : Condition
	{
		// Token: 0x06014A23 RID: 84515 RVA: 0x00636975 File Offset: 0x00634D75
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node5()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x06014A24 RID: 84516 RVA: 0x00636984 File Offset: 0x00634D84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E381 RID: 58241
		private EventType opl_p0;
	}
}
