using System;

namespace behaviac
{
	// Token: 0x020027C1 RID: 10177
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node19 : Condition
	{
		// Token: 0x060138C1 RID: 80065 RVA: 0x005D4623 File Offset: 0x005D2A23
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node19()
		{
			this.opl_p0 = 3615;
		}

		// Token: 0x060138C2 RID: 80066 RVA: 0x005D4638 File Offset: 0x005D2A38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D320 RID: 54048
		private int opl_p0;
	}
}
