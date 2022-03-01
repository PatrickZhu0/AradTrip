using System;

namespace behaviac
{
	// Token: 0x02002E37 RID: 11831
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node118 : Condition
	{
		// Token: 0x0601454B RID: 83275 RVA: 0x0061A9CF File Offset: 0x00618DCF
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node118()
		{
			this.opl_p0 = 21631;
		}

		// Token: 0x0601454C RID: 83276 RVA: 0x0061A9E4 File Offset: 0x00618DE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEE3 RID: 57059
		private int opl_p0;
	}
}
