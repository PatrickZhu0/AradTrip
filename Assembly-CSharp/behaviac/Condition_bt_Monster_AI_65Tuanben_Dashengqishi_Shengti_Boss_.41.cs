using System;

namespace behaviac
{
	// Token: 0x02002E13 RID: 11795
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node32 : Condition
	{
		// Token: 0x06014503 RID: 83203 RVA: 0x00619BF2 File Offset: 0x00617FF2
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node32()
		{
			this.opl_p0 = 21653;
		}

		// Token: 0x06014504 RID: 83204 RVA: 0x00619C08 File Offset: 0x00618008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEAA RID: 57002
		private int opl_p0;
	}
}
