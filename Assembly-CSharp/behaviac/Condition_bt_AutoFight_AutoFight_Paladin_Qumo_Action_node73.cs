using System;

namespace behaviac
{
	// Token: 0x020027F1 RID: 10225
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node73 : Condition
	{
		// Token: 0x06013921 RID: 80161 RVA: 0x005D5A93 File Offset: 0x005D3E93
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node73()
		{
			this.opl_p0 = 3604;
		}

		// Token: 0x06013922 RID: 80162 RVA: 0x005D5AA8 File Offset: 0x005D3EA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D380 RID: 54144
		private int opl_p0;
	}
}
