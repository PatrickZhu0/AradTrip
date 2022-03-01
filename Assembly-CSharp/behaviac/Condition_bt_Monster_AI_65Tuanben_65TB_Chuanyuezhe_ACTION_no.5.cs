using System;

namespace behaviac
{
	// Token: 0x02002B40 RID: 11072
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node37 : Condition
	{
		// Token: 0x06013F8E RID: 81806 RVA: 0x005FEEDA File Offset: 0x005FD2DA
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node37()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.85f;
		}

		// Token: 0x06013F8F RID: 81807 RVA: 0x005FEEFC File Offset: 0x005FD2FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9B2 RID: 55730
		private HMType opl_p0;

		// Token: 0x0400D9B3 RID: 55731
		private BE_Operation opl_p1;

		// Token: 0x0400D9B4 RID: 55732
		private float opl_p2;
	}
}
