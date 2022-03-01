using System;

namespace behaviac
{
	// Token: 0x02002E71 RID: 11889
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node272 : Condition
	{
		// Token: 0x060145BF RID: 83391 RVA: 0x0061C1AF File Offset: 0x0061A5AF
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node272()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x060145C0 RID: 83392 RVA: 0x0061C1D0 File Offset: 0x0061A5D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF46 RID: 57158
		private HMType opl_p0;

		// Token: 0x0400DF47 RID: 57159
		private BE_Operation opl_p1;

		// Token: 0x0400DF48 RID: 57160
		private float opl_p2;
	}
}
