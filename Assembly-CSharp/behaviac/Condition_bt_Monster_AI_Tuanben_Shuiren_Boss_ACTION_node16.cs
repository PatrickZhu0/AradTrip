using System;

namespace behaviac
{
	// Token: 0x02003B44 RID: 15172
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node16 : Condition
	{
		// Token: 0x06015E3D RID: 89661 RVA: 0x0069D495 File Offset: 0x0069B895
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node16()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06015E3E RID: 89662 RVA: 0x0069D4B8 File Offset: 0x0069B8B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F713 RID: 63251
		private HMType opl_p0;

		// Token: 0x0400F714 RID: 63252
		private BE_Operation opl_p1;

		// Token: 0x0400F715 RID: 63253
		private float opl_p2;
	}
}
