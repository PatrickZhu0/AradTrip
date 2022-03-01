using System;

namespace behaviac
{
	// Token: 0x02002CD3 RID: 11475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node26 : Condition
	{
		// Token: 0x06014296 RID: 82582 RVA: 0x0060E62D File Offset: 0x0060CA2D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node26()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014297 RID: 82583 RVA: 0x0060E650 File Offset: 0x0060CA50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC4A RID: 56394
		private HMType opl_p0;

		// Token: 0x0400DC4B RID: 56395
		private BE_Operation opl_p1;

		// Token: 0x0400DC4C RID: 56396
		private float opl_p2;
	}
}
