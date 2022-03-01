using System;

namespace behaviac
{
	// Token: 0x02003D71 RID: 15729
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node5 : Condition
	{
		// Token: 0x06016277 RID: 90743 RVA: 0x006B2941 File Offset: 0x006B0D41
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node5()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.9f;
		}

		// Token: 0x06016278 RID: 90744 RVA: 0x006B2964 File Offset: 0x006B0D64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FACF RID: 64207
		private HMType opl_p0;

		// Token: 0x0400FAD0 RID: 64208
		private BE_Operation opl_p1;

		// Token: 0x0400FAD1 RID: 64209
		private float opl_p2;
	}
}
