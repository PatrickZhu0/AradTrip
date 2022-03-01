using System;

namespace behaviac
{
	// Token: 0x02003D79 RID: 15737
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node11 : Condition
	{
		// Token: 0x06016287 RID: 90759 RVA: 0x006B2C11 File Offset: 0x006B1011
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node11()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x06016288 RID: 90760 RVA: 0x006B2C34 File Offset: 0x006B1034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FADD RID: 64221
		private HMType opl_p0;

		// Token: 0x0400FADE RID: 64222
		private BE_Operation opl_p1;

		// Token: 0x0400FADF RID: 64223
		private float opl_p2;
	}
}
