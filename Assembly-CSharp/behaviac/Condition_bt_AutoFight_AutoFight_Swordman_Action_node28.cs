using System;

namespace behaviac
{
	// Token: 0x0200287A RID: 10362
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node28 : Condition
	{
		// Token: 0x06013A31 RID: 80433 RVA: 0x005DCBC5 File Offset: 0x005DAFC5
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node28()
		{
			this.opl_p0 = 1701;
		}

		// Token: 0x06013A32 RID: 80434 RVA: 0x005DCBD8 File Offset: 0x005DAFD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D48B RID: 54411
		private int opl_p0;
	}
}
