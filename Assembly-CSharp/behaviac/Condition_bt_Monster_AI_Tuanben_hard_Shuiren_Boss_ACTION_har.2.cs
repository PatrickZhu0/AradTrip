using System;

namespace behaviac
{
	// Token: 0x02003D3A RID: 15674
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node35 : Condition
	{
		// Token: 0x0601620A RID: 90634 RVA: 0x006B0799 File Offset: 0x006AEB99
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node35()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x0601620B RID: 90635 RVA: 0x006B07BC File Offset: 0x006AEBBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA78 RID: 64120
		private HMType opl_p0;

		// Token: 0x0400FA79 RID: 64121
		private BE_Operation opl_p1;

		// Token: 0x0400FA7A RID: 64122
		private float opl_p2;
	}
}
