using System;

namespace behaviac
{
	// Token: 0x02003B19 RID: 15129
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node5 : Condition
	{
		// Token: 0x06015DEA RID: 89578 RVA: 0x0069BC31 File Offset: 0x0069A031
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node5()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.9f;
		}

		// Token: 0x06015DEB RID: 89579 RVA: 0x0069BC54 File Offset: 0x0069A054
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6D0 RID: 63184
		private HMType opl_p0;

		// Token: 0x0400F6D1 RID: 63185
		private BE_Operation opl_p1;

		// Token: 0x0400F6D2 RID: 63186
		private float opl_p2;
	}
}
