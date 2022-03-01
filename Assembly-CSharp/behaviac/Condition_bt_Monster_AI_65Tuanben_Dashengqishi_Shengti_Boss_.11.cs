using System;

namespace behaviac
{
	// Token: 0x02002DDD RID: 11741
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node81 : Condition
	{
		// Token: 0x06014497 RID: 83095 RVA: 0x00618643 File Offset: 0x00616A43
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node81()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06014498 RID: 83096 RVA: 0x00618664 File Offset: 0x00616A64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE4E RID: 56910
		private HMType opl_p0;

		// Token: 0x0400DE4F RID: 56911
		private BE_Operation opl_p1;

		// Token: 0x0400DE50 RID: 56912
		private float opl_p2;
	}
}
