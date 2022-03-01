using System;

namespace behaviac
{
	// Token: 0x02002E4E RID: 11854
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node236 : Condition
	{
		// Token: 0x06014579 RID: 83321 RVA: 0x0061B360 File Offset: 0x00619760
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node236()
		{
			this.opl_p0 = 21626;
		}

		// Token: 0x0601457A RID: 83322 RVA: 0x0061B374 File Offset: 0x00619774
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF0B RID: 57099
		private int opl_p0;
	}
}
