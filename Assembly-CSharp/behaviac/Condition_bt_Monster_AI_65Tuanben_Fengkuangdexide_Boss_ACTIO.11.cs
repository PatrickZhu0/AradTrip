using System;

namespace behaviac
{
	// Token: 0x02002EB9 RID: 11961
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node33 : Condition
	{
		// Token: 0x0601464C RID: 83532 RVA: 0x00622193 File Offset: 0x00620593
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node33()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.31f;
		}

		// Token: 0x0601464D RID: 83533 RVA: 0x006221B4 File Offset: 0x006205B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFBF RID: 57279
		private HMType opl_p0;

		// Token: 0x0400DFC0 RID: 57280
		private BE_Operation opl_p1;

		// Token: 0x0400DFC1 RID: 57281
		private float opl_p2;
	}
}
