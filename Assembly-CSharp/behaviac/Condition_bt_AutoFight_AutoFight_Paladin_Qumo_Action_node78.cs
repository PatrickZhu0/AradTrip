using System;

namespace behaviac
{
	// Token: 0x020027ED RID: 10221
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node78 : Condition
	{
		// Token: 0x06013919 RID: 80153 RVA: 0x005D58DF File Offset: 0x005D3CDF
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node78()
		{
			this.opl_p0 = 3612;
		}

		// Token: 0x0601391A RID: 80154 RVA: 0x005D58F4 File Offset: 0x005D3CF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D378 RID: 54136
		private int opl_p0;
	}
}
