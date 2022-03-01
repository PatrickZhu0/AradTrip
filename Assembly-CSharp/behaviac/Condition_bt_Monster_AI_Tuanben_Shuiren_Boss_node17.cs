using System;

namespace behaviac
{
	// Token: 0x02003B29 RID: 15145
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node17 : Condition
	{
		// Token: 0x06015E0A RID: 89610 RVA: 0x0069C1D1 File Offset: 0x0069A5D1
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node17()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06015E0B RID: 89611 RVA: 0x0069C1F4 File Offset: 0x0069A5F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6EC RID: 63212
		private HMType opl_p0;

		// Token: 0x0400F6ED RID: 63213
		private BE_Operation opl_p1;

		// Token: 0x0400F6EE RID: 63214
		private float opl_p2;
	}
}
