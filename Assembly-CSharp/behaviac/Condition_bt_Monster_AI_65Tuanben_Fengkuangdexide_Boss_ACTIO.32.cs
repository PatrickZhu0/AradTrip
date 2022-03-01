using System;

namespace behaviac
{
	// Token: 0x02002EDA RID: 11994
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node70 : Condition
	{
		// Token: 0x0601468E RID: 83598 RVA: 0x00622D5F File Offset: 0x0062115F
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node70()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x0601468F RID: 83599 RVA: 0x00622D80 File Offset: 0x00621180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E000 RID: 57344
		private HMType opl_p0;

		// Token: 0x0400E001 RID: 57345
		private BE_Operation opl_p1;

		// Token: 0x0400E002 RID: 57346
		private float opl_p2;
	}
}
