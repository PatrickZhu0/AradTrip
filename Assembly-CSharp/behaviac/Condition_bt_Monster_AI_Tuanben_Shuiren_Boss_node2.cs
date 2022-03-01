using System;

namespace behaviac
{
	// Token: 0x02003B39 RID: 15161
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node2 : Condition
	{
		// Token: 0x06015E2A RID: 89642 RVA: 0x0069C771 File Offset: 0x0069AB71
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x06015E2B RID: 89643 RVA: 0x0069C794 File Offset: 0x0069AB94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F708 RID: 63240
		private HMType opl_p0;

		// Token: 0x0400F709 RID: 63241
		private BE_Operation opl_p1;

		// Token: 0x0400F70A RID: 63242
		private float opl_p2;
	}
}
