using System;

namespace behaviac
{
	// Token: 0x02002EB8 RID: 11960
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node32 : Condition
	{
		// Token: 0x0601464A RID: 83530 RVA: 0x00622131 File Offset: 0x00620531
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node32()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x0601464B RID: 83531 RVA: 0x00622154 File Offset: 0x00620554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFBC RID: 57276
		private HMType opl_p0;

		// Token: 0x0400DFBD RID: 57277
		private BE_Operation opl_p1;

		// Token: 0x0400DFBE RID: 57278
		private float opl_p2;
	}
}
