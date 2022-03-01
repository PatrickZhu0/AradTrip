using System;

namespace behaviac
{
	// Token: 0x02003B25 RID: 15141
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node14 : Condition
	{
		// Token: 0x06015E02 RID: 89602 RVA: 0x0069C069 File Offset: 0x0069A469
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node14()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x06015E03 RID: 89603 RVA: 0x0069C08C File Offset: 0x0069A48C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6E5 RID: 63205
		private HMType opl_p0;

		// Token: 0x0400F6E6 RID: 63206
		private BE_Operation opl_p1;

		// Token: 0x0400F6E7 RID: 63207
		private float opl_p2;
	}
}
