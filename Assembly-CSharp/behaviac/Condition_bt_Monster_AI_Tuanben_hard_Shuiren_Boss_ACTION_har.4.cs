using System;

namespace behaviac
{
	// Token: 0x02003D3E RID: 15678
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node16 : Condition
	{
		// Token: 0x06016212 RID: 90642 RVA: 0x006B0885 File Offset: 0x006AEC85
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node16()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06016213 RID: 90643 RVA: 0x006B08A8 File Offset: 0x006AECA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA7C RID: 64124
		private HMType opl_p0;

		// Token: 0x0400FA7D RID: 64125
		private BE_Operation opl_p1;

		// Token: 0x0400FA7E RID: 64126
		private float opl_p2;
	}
}
