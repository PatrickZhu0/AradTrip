using System;

namespace behaviac
{
	// Token: 0x020027F9 RID: 10233
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node88 : Condition
	{
		// Token: 0x06013931 RID: 80177 RVA: 0x005D5DFB File Offset: 0x005D41FB
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node88()
		{
			this.opl_p0 = 3504;
		}

		// Token: 0x06013932 RID: 80178 RVA: 0x005D5E10 File Offset: 0x005D4210
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D390 RID: 54160
		private int opl_p0;
	}
}
