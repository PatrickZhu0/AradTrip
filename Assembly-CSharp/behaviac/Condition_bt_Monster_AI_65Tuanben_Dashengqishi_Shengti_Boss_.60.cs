using System;

namespace behaviac
{
	// Token: 0x02002E36 RID: 11830
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node117 : Condition
	{
		// Token: 0x06014549 RID: 83273 RVA: 0x0061A96D File Offset: 0x00618D6D
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node117()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x0601454A RID: 83274 RVA: 0x0061A990 File Offset: 0x00618D90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEE0 RID: 57056
		private HMType opl_p0;

		// Token: 0x0400DEE1 RID: 57057
		private BE_Operation opl_p1;

		// Token: 0x0400DEE2 RID: 57058
		private float opl_p2;
	}
}
