using System;

namespace behaviac
{
	// Token: 0x02003285 RID: 12933
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node6 : Condition
	{
		// Token: 0x06014D85 RID: 85381 RVA: 0x006477C1 File Offset: 0x00645BC1
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi3_Event_node6()
		{
			this.opl_p0 = 570172;
		}

		// Token: 0x06014D86 RID: 85382 RVA: 0x006477D4 File Offset: 0x00645BD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E694 RID: 59028
		private int opl_p0;
	}
}
