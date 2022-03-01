using System;

namespace behaviac
{
	// Token: 0x02003D7D RID: 15741
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node14 : Condition
	{
		// Token: 0x0601628F RID: 90767 RVA: 0x006B2D79 File Offset: 0x006B1179
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node14()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x06016290 RID: 90768 RVA: 0x006B2D9C File Offset: 0x006B119C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAE4 RID: 64228
		private HMType opl_p0;

		// Token: 0x0400FAE5 RID: 64229
		private BE_Operation opl_p1;

		// Token: 0x0400FAE6 RID: 64230
		private float opl_p2;
	}
}
