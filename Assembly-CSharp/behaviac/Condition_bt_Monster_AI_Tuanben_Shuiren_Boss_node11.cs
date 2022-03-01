using System;

namespace behaviac
{
	// Token: 0x02003B21 RID: 15137
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node11 : Condition
	{
		// Token: 0x06015DFA RID: 89594 RVA: 0x0069BF01 File Offset: 0x0069A301
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node11()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06015DFB RID: 89595 RVA: 0x0069BF24 File Offset: 0x0069A324
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6DE RID: 63198
		private HMType opl_p0;

		// Token: 0x0400F6DF RID: 63199
		private BE_Operation opl_p1;

		// Token: 0x0400F6E0 RID: 63200
		private float opl_p2;
	}
}
