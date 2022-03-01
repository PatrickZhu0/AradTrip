using System;

namespace behaviac
{
	// Token: 0x02002EFF RID: 12031
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node5 : Condition
	{
		// Token: 0x060146D6 RID: 83670 RVA: 0x00624E35 File Offset: 0x00623235
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node5()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x060146D7 RID: 83671 RVA: 0x00624E58 File Offset: 0x00623258
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E04C RID: 57420
		private HMType opl_p0;

		// Token: 0x0400E04D RID: 57421
		private BE_Operation opl_p1;

		// Token: 0x0400E04E RID: 57422
		private float opl_p2;
	}
}
