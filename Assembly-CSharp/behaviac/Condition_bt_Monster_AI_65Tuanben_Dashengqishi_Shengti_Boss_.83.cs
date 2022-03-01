using System;

namespace behaviac
{
	// Token: 0x02002E5C RID: 11868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node243 : Condition
	{
		// Token: 0x06014595 RID: 83349 RVA: 0x0061B92B File Offset: 0x00619D2B
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node243()
		{
			this.opl_p0 = 21633;
		}

		// Token: 0x06014596 RID: 83350 RVA: 0x0061B940 File Offset: 0x00619D40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF26 RID: 57126
		private int opl_p0;
	}
}
