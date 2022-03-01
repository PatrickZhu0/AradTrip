using System;

namespace behaviac
{
	// Token: 0x02002C2B RID: 11307
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node7 : Condition
	{
		// Token: 0x06014154 RID: 82260 RVA: 0x00608045 File Offset: 0x00606445
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node7()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014155 RID: 82261 RVA: 0x00608068 File Offset: 0x00606468
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB22 RID: 56098
		private HMType opl_p0;

		// Token: 0x0400DB23 RID: 56099
		private BE_Operation opl_p1;

		// Token: 0x0400DB24 RID: 56100
		private float opl_p2;
	}
}
