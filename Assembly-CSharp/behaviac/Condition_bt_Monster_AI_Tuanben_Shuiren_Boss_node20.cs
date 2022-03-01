using System;

namespace behaviac
{
	// Token: 0x02003B2D RID: 15149
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node20 : Condition
	{
		// Token: 0x06015E12 RID: 89618 RVA: 0x0069C339 File Offset: 0x0069A739
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06015E13 RID: 89619 RVA: 0x0069C35C File Offset: 0x0069A75C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6F3 RID: 63219
		private HMType opl_p0;

		// Token: 0x0400F6F4 RID: 63220
		private BE_Operation opl_p1;

		// Token: 0x0400F6F5 RID: 63221
		private float opl_p2;
	}
}
