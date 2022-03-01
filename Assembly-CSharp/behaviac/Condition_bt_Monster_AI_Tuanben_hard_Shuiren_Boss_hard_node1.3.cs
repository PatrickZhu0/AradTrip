using System;

namespace behaviac
{
	// Token: 0x02003D81 RID: 15745
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node17 : Condition
	{
		// Token: 0x06016297 RID: 90775 RVA: 0x006B2EE1 File Offset: 0x006B12E1
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node17()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06016298 RID: 90776 RVA: 0x006B2F04 File Offset: 0x006B1304
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAEB RID: 64235
		private HMType opl_p0;

		// Token: 0x0400FAEC RID: 64236
		private BE_Operation opl_p1;

		// Token: 0x0400FAED RID: 64237
		private float opl_p2;
	}
}
