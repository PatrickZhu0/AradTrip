using System;

namespace behaviac
{
	// Token: 0x02002E1B RID: 11803
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node130 : Condition
	{
		// Token: 0x06014513 RID: 83219 RVA: 0x00619FA9 File Offset: 0x006183A9
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node130()
		{
			this.opl_p0 = 21623;
		}

		// Token: 0x06014514 RID: 83220 RVA: 0x00619FBC File Offset: 0x006183BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEBA RID: 57018
		private int opl_p0;
	}
}
