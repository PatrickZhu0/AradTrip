using System;

namespace behaviac
{
	// Token: 0x02003258 RID: 12888
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node14 : Condition
	{
		// Token: 0x06014D2F RID: 85295 RVA: 0x006460F1 File Offset: 0x006444F1
		public Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node14()
		{
			this.opl_p0 = 570172;
		}

		// Token: 0x06014D30 RID: 85296 RVA: 0x00646104 File Offset: 0x00644504
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E674 RID: 58996
		private int opl_p0;
	}
}
