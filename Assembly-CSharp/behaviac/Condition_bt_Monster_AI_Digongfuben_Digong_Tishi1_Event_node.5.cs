using System;

namespace behaviac
{
	// Token: 0x0200326D RID: 12909
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node6 : Condition
	{
		// Token: 0x06014D57 RID: 85335 RVA: 0x00646B79 File Offset: 0x00644F79
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node6()
		{
			this.opl_p0 = 570205;
		}

		// Token: 0x06014D58 RID: 85336 RVA: 0x00646B8C File Offset: 0x00644F8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E688 RID: 59016
		private int opl_p0;
	}
}
