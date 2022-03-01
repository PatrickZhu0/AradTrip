using System;

namespace behaviac
{
	// Token: 0x02002C48 RID: 11336
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node16 : Condition
	{
		// Token: 0x0601418C RID: 82316 RVA: 0x00608EC3 File Offset: 0x006072C3
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node16()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601418D RID: 82317 RVA: 0x00608ED8 File Offset: 0x006072D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB55 RID: 56149
		private float opl_p0;
	}
}
