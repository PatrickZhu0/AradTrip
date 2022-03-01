using System;

namespace behaviac
{
	// Token: 0x02002E74 RID: 11892
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node276 : Condition
	{
		// Token: 0x060145C5 RID: 83397 RVA: 0x0061C303 File Offset: 0x0061A703
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node276()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x060145C6 RID: 83398 RVA: 0x0061C324 File Offset: 0x0061A724
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF4C RID: 57164
		private HMType opl_p0;

		// Token: 0x0400DF4D RID: 57165
		private BE_Operation opl_p1;

		// Token: 0x0400DF4E RID: 57166
		private float opl_p2;
	}
}
