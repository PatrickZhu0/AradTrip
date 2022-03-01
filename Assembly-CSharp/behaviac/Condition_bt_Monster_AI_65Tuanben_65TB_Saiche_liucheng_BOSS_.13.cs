using System;

namespace behaviac
{
	// Token: 0x02002BF1 RID: 11249
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node67 : Condition
	{
		// Token: 0x060140E1 RID: 82145 RVA: 0x00605701 File Offset: 0x00603B01
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node67()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x060140E2 RID: 82146 RVA: 0x00605724 File Offset: 0x00603B24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAC0 RID: 56000
		private HMType opl_p0;

		// Token: 0x0400DAC1 RID: 56001
		private BE_Operation opl_p1;

		// Token: 0x0400DAC2 RID: 56002
		private float opl_p2;
	}
}
