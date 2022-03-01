using System;

namespace behaviac
{
	// Token: 0x02002DE4 RID: 11748
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node83 : Condition
	{
		// Token: 0x060144A5 RID: 83109 RVA: 0x0061897F File Offset: 0x00616D7F
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node83()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.9f;
		}

		// Token: 0x060144A6 RID: 83110 RVA: 0x006189A0 File Offset: 0x00616DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE5A RID: 56922
		private HMType opl_p0;

		// Token: 0x0400DE5B RID: 56923
		private BE_Operation opl_p1;

		// Token: 0x0400DE5C RID: 56924
		private float opl_p2;
	}
}
