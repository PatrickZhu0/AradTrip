using System;

namespace behaviac
{
	// Token: 0x02002E2C RID: 11820
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node192 : Condition
	{
		// Token: 0x06014535 RID: 83253 RVA: 0x0061A611 File Offset: 0x00618A11
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node192()
		{
			this.opl_p0 = 21638;
		}

		// Token: 0x06014536 RID: 83254 RVA: 0x0061A624 File Offset: 0x00618A24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DED4 RID: 57044
		private int opl_p0;
	}
}
