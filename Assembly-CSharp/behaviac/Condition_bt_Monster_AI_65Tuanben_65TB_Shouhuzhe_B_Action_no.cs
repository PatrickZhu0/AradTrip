using System;

namespace behaviac
{
	// Token: 0x02002C54 RID: 11348
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node7 : Condition
	{
		// Token: 0x060141A3 RID: 82339 RVA: 0x006099A3 File Offset: 0x00607DA3
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node7()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060141A4 RID: 82340 RVA: 0x006099C4 File Offset: 0x00607DC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB6C RID: 56172
		private HMType opl_p0;

		// Token: 0x0400DB6D RID: 56173
		private BE_Operation opl_p1;

		// Token: 0x0400DB6E RID: 56174
		private float opl_p2;
	}
}
