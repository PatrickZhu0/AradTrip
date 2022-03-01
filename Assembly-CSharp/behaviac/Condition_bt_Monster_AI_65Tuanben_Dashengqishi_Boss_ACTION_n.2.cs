using System;

namespace behaviac
{
	// Token: 0x02002D88 RID: 11656
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node132 : Condition
	{
		// Token: 0x060143F1 RID: 82929 RVA: 0x00615571 File Offset: 0x00613971
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node132()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x060143F2 RID: 82930 RVA: 0x00615594 File Offset: 0x00613994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDC1 RID: 56769
		private HMType opl_p0;

		// Token: 0x0400DDC2 RID: 56770
		private BE_Operation opl_p1;

		// Token: 0x0400DDC3 RID: 56771
		private float opl_p2;
	}
}
