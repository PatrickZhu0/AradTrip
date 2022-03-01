using System;

namespace behaviac
{
	// Token: 0x02003240 RID: 12864
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node10 : Condition
	{
		// Token: 0x06014D02 RID: 85250 RVA: 0x00645391 File Offset: 0x00643791
		public Condition_bt_Monster_AI_Digongfuben_Digong_Baoxiang_Event_node10()
		{
			this.opl_p0 = 570205;
		}

		// Token: 0x06014D03 RID: 85251 RVA: 0x006453A4 File Offset: 0x006437A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E658 RID: 58968
		private int opl_p0;
	}
}
