using System;

namespace behaviac
{
	// Token: 0x02003CD1 RID: 15569
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node90 : Condition
	{
		// Token: 0x06016144 RID: 90436 RVA: 0x006AC83D File Offset: 0x006AAC3D
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node90()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x06016145 RID: 90437 RVA: 0x006AC84C File Offset: 0x006AAC4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEventNew(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9F6 RID: 63990
		private EventType opl_p0;
	}
}
