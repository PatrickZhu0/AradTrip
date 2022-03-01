using System;

namespace behaviac
{
	// Token: 0x02003D89 RID: 15753
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node26 : Condition
	{
		// Token: 0x060162A7 RID: 90791 RVA: 0x006B31B1 File Offset: 0x006B15B1
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node26()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x060162A8 RID: 90792 RVA: 0x006B31D4 File Offset: 0x006B15D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAF9 RID: 64249
		private HMType opl_p0;

		// Token: 0x0400FAFA RID: 64250
		private BE_Operation opl_p1;

		// Token: 0x0400FAFB RID: 64251
		private float opl_p2;
	}
}
