using System;

namespace behaviac
{
	// Token: 0x02002EB2 RID: 11954
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node29 : Condition
	{
		// Token: 0x0601463E RID: 83518 RVA: 0x00621F1F File Offset: 0x0062031F
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node29()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.61f;
		}

		// Token: 0x0601463F RID: 83519 RVA: 0x00621F40 File Offset: 0x00620340
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFB3 RID: 57267
		private HMType opl_p0;

		// Token: 0x0400DFB4 RID: 57268
		private BE_Operation opl_p1;

		// Token: 0x0400DFB5 RID: 57269
		private float opl_p2;
	}
}
