using System;

namespace behaviac
{
	// Token: 0x02002C33 RID: 11315
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node6 : Condition
	{
		// Token: 0x06014164 RID: 82276 RVA: 0x006082D2 File Offset: 0x006066D2
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node6()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014165 RID: 82277 RVA: 0x006082F4 File Offset: 0x006066F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB2B RID: 56107
		private HMType opl_p0;

		// Token: 0x0400DB2C RID: 56108
		private BE_Operation opl_p1;

		// Token: 0x0400DB2D RID: 56109
		private float opl_p2;
	}
}
