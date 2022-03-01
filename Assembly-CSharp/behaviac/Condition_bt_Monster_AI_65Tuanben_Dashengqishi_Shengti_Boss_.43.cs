using System;

namespace behaviac
{
	// Token: 0x02002E17 RID: 11799
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node159 : Condition
	{
		// Token: 0x0601450B RID: 83211 RVA: 0x00619DDA File Offset: 0x006181DA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node159()
		{
			this.opl_p0 = 21640;
		}

		// Token: 0x0601450C RID: 83212 RVA: 0x00619DF0 File Offset: 0x006181F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEB0 RID: 57008
		private int opl_p0;
	}
}
