using System;

namespace behaviac
{
	// Token: 0x02002E30 RID: 11824
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node110 : Condition
	{
		// Token: 0x0601453D RID: 83261 RVA: 0x0061A77D File Offset: 0x00618B7D
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node110()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x0601453E RID: 83262 RVA: 0x0061A7A0 File Offset: 0x00618BA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DED8 RID: 57048
		private HMType opl_p0;

		// Token: 0x0400DED9 RID: 57049
		private BE_Operation opl_p1;

		// Token: 0x0400DEDA RID: 57050
		private float opl_p2;
	}
}
