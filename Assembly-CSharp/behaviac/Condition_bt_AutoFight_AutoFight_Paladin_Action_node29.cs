using System;

namespace behaviac
{
	// Token: 0x020027A5 RID: 10149
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node29 : Condition
	{
		// Token: 0x0601388A RID: 80010 RVA: 0x005D2CEF File Offset: 0x005D10EF
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node29()
		{
			this.opl_p0 = 3509;
		}

		// Token: 0x0601388B RID: 80011 RVA: 0x005D2D04 File Offset: 0x005D1104
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2EA RID: 53994
		private int opl_p0;
	}
}
