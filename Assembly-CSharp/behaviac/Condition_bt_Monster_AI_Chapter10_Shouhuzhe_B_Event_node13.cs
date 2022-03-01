using System;

namespace behaviac
{
	// Token: 0x0200313F RID: 12607
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node13 : Condition
	{
		// Token: 0x06014B21 RID: 84769 RVA: 0x0063B66B File Offset: 0x00639A6B
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node13()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06014B22 RID: 84770 RVA: 0x0063B68C File Offset: 0x00639A8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E49B RID: 58523
		private HMType opl_p0;

		// Token: 0x0400E49C RID: 58524
		private BE_Operation opl_p1;

		// Token: 0x0400E49D RID: 58525
		private float opl_p2;
	}
}
