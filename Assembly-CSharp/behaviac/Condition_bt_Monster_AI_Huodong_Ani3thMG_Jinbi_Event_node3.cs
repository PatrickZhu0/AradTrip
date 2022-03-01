using System;

namespace behaviac
{
	// Token: 0x02003565 RID: 13669
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node3 : Condition
	{
		// Token: 0x06015304 RID: 86788 RVA: 0x00662DE8 File Offset: 0x006611E8
		public Condition_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node3()
		{
			this.opl_p0 = 1000;
		}

		// Token: 0x06015305 RID: 86789 RVA: 0x00662DFC File Offset: 0x006611FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsPlayerAround(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECBA RID: 60602
		private int opl_p0;
	}
}
