using System;

namespace behaviac
{
	// Token: 0x02002C71 RID: 11377
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node16 : Condition
	{
		// Token: 0x060141DB RID: 82395 RVA: 0x0060A81F File Offset: 0x00608C1F
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node16()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060141DC RID: 82396 RVA: 0x0060A834 File Offset: 0x00608C34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB9F RID: 56223
		private float opl_p0;
	}
}
