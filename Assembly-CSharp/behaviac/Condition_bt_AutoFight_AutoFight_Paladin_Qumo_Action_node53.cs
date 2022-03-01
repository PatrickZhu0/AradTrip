using System;

namespace behaviac
{
	// Token: 0x020027DD RID: 10205
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node53 : Condition
	{
		// Token: 0x060138F9 RID: 80121 RVA: 0x005D520F File Offset: 0x005D360F
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node53()
		{
			this.opl_p0 = 3610;
		}

		// Token: 0x060138FA RID: 80122 RVA: 0x005D5224 File Offset: 0x005D3624
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D358 RID: 54104
		private int opl_p0;
	}
}
