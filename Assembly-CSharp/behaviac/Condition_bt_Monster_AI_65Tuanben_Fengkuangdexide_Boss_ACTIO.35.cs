using System;

namespace behaviac
{
	// Token: 0x02002EDE RID: 11998
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node75 : Condition
	{
		// Token: 0x06014696 RID: 83606 RVA: 0x00622F2A File Offset: 0x0062132A
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node75()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06014697 RID: 83607 RVA: 0x00622F4C File Offset: 0x0062134C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E00A RID: 57354
		private HMType opl_p0;

		// Token: 0x0400E00B RID: 57355
		private BE_Operation opl_p1;

		// Token: 0x0400E00C RID: 57356
		private float opl_p2;
	}
}
