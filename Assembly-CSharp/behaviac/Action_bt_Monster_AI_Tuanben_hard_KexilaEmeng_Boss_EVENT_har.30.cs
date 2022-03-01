using System;

namespace behaviac
{
	// Token: 0x02003C01 RID: 15361
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node24 : Action
	{
		// Token: 0x06015FAE RID: 90030 RVA: 0x006A361A File Offset: 0x006A1A1A
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x06015FAF RID: 90031 RVA: 0x006A3630 File Offset: 0x006A1A30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F835 RID: 63541
		private int method_p0;
	}
}
