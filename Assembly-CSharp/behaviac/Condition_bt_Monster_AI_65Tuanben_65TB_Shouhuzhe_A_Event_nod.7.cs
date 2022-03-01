using System;

namespace behaviac
{
	// Token: 0x02002C47 RID: 11335
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node15 : Condition
	{
		// Token: 0x0601418A RID: 82314 RVA: 0x00608E63 File Offset: 0x00607263
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node15()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x0601418B RID: 82315 RVA: 0x00608E84 File Offset: 0x00607284
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB52 RID: 56146
		private HMType opl_p0;

		// Token: 0x0400DB53 RID: 56147
		private BE_Operation opl_p1;

		// Token: 0x0400DB54 RID: 56148
		private float opl_p2;
	}
}
