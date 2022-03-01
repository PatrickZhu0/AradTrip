using System;

namespace behaviac
{
	// Token: 0x02002DA7 RID: 11687
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node51 : Condition
	{
		// Token: 0x0601442F RID: 82991 RVA: 0x00616073 File Offset: 0x00614473
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node51()
		{
			this.opl_p0 = 21652;
		}

		// Token: 0x06014430 RID: 82992 RVA: 0x00616088 File Offset: 0x00614488
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDF4 RID: 56820
		private int opl_p0;
	}
}
