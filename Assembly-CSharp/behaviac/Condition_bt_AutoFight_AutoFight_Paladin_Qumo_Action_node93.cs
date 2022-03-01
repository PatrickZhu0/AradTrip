using System;

namespace behaviac
{
	// Token: 0x020027FD RID: 10237
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node93 : Condition
	{
		// Token: 0x06013939 RID: 80185 RVA: 0x005D5FAF File Offset: 0x005D43AF
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node93()
		{
			this.opl_p0 = 3507;
		}

		// Token: 0x0601393A RID: 80186 RVA: 0x005D5FC4 File Offset: 0x005D43C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D398 RID: 54168
		private int opl_p0;
	}
}
