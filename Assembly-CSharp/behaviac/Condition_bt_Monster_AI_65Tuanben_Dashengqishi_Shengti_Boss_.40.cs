using System;

namespace behaviac
{
	// Token: 0x02002E11 RID: 11793
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node152 : Condition
	{
		// Token: 0x060144FF RID: 83199 RVA: 0x00619AE7 File Offset: 0x00617EE7
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node152()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06014500 RID: 83200 RVA: 0x00619B08 File Offset: 0x00617F08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEA5 RID: 56997
		private HMType opl_p0;

		// Token: 0x0400DEA6 RID: 56998
		private BE_Operation opl_p1;

		// Token: 0x0400DEA7 RID: 56999
		private float opl_p2;
	}
}
