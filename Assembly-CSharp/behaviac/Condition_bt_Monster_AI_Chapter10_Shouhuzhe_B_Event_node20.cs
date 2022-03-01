using System;

namespace behaviac
{
	// Token: 0x02003144 RID: 12612
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node20 : Condition
	{
		// Token: 0x06014B2B RID: 84779 RVA: 0x0063B859 File Offset: 0x00639C59
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.35f;
		}

		// Token: 0x06014B2C RID: 84780 RVA: 0x0063B87C File Offset: 0x00639C7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4A4 RID: 58532
		private HMType opl_p0;

		// Token: 0x0400E4A5 RID: 58533
		private BE_Operation opl_p1;

		// Token: 0x0400E4A6 RID: 58534
		private float opl_p2;
	}
}
