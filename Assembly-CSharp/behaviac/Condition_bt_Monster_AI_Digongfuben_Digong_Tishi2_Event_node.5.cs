using System;

namespace behaviac
{
	// Token: 0x02003279 RID: 12921
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node6 : Condition
	{
		// Token: 0x06014D6E RID: 85358 RVA: 0x0064719D File Offset: 0x0064559D
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi2_Event_node6()
		{
			this.opl_p0 = 570206;
		}

		// Token: 0x06014D6F RID: 85359 RVA: 0x006471B0 File Offset: 0x006455B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E68E RID: 59022
		private int opl_p0;
	}
}
