using System;

namespace behaviac
{
	// Token: 0x02002E6C RID: 11884
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node268 : Condition
	{
		// Token: 0x060145B5 RID: 83381 RVA: 0x0061BF67 File Offset: 0x0061A367
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node268()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x060145B6 RID: 83382 RVA: 0x0061BF88 File Offset: 0x0061A388
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF3D RID: 57149
		private HMType opl_p0;

		// Token: 0x0400DF3E RID: 57150
		private BE_Operation opl_p1;

		// Token: 0x0400DF3F RID: 57151
		private float opl_p2;
	}
}
