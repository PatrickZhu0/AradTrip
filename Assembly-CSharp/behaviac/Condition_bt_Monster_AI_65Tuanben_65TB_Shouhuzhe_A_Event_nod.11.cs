using System;

namespace behaviac
{
	// Token: 0x02002C4C RID: 11340
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node20 : Condition
	{
		// Token: 0x06014194 RID: 82324 RVA: 0x00609051 File Offset: 0x00607451
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06014195 RID: 82325 RVA: 0x00609074 File Offset: 0x00607474
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB5B RID: 56155
		private HMType opl_p0;

		// Token: 0x0400DB5C RID: 56156
		private BE_Operation opl_p1;

		// Token: 0x0400DB5D RID: 56157
		private float opl_p2;
	}
}
