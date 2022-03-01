using System;

namespace behaviac
{
	// Token: 0x02003D75 RID: 15733
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node8 : Condition
	{
		// Token: 0x0601627F RID: 90751 RVA: 0x006B2AA9 File Offset: 0x006B0EA9
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node8()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x06016280 RID: 90752 RVA: 0x006B2ACC File Offset: 0x006B0ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAD6 RID: 64214
		private HMType opl_p0;

		// Token: 0x0400FAD7 RID: 64215
		private BE_Operation opl_p1;

		// Token: 0x0400FAD8 RID: 64216
		private float opl_p2;
	}
}
