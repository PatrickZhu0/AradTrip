using System;

namespace behaviac
{
	// Token: 0x02001F44 RID: 8004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node43 : Condition
	{
		// Token: 0x0601282B RID: 75819 RVA: 0x0056AD03 File Offset: 0x00569103
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node43()
		{
			this.opl_p0 = 3206;
		}

		// Token: 0x0601282C RID: 75820 RVA: 0x0056AD18 File Offset: 0x00569118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C224 RID: 49700
		private int opl_p0;
	}
}
