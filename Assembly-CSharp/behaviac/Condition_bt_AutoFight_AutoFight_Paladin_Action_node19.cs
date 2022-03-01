using System;

namespace behaviac
{
	// Token: 0x0200279D RID: 10141
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node19 : Condition
	{
		// Token: 0x0601387A RID: 79994 RVA: 0x005D2987 File Offset: 0x005D0D87
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node19()
		{
			this.opl_p0 = 3507;
		}

		// Token: 0x0601387B RID: 79995 RVA: 0x005D299C File Offset: 0x005D0D9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2DA RID: 53978
		private int opl_p0;
	}
}
