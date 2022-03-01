using System;

namespace behaviac
{
	// Token: 0x02003129 RID: 12585
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node15 : Condition
	{
		// Token: 0x06014AF7 RID: 84727 RVA: 0x0063A925 File Offset: 0x00638D25
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node15()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014AF8 RID: 84728 RVA: 0x0063A948 File Offset: 0x00638D48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E46A RID: 58474
		private HMType opl_p0;

		// Token: 0x0400E46B RID: 58475
		private BE_Operation opl_p1;

		// Token: 0x0400E46C RID: 58476
		private float opl_p2;
	}
}
