using System;

namespace behaviac
{
	// Token: 0x0200256A RID: 9578
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node7 : Condition
	{
		// Token: 0x0601341C RID: 78876 RVA: 0x005B9889 File Offset: 0x005B7C89
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node7()
		{
			this.opl_p0 = 1005;
		}

		// Token: 0x0601341D RID: 78877 RVA: 0x005B989C File Offset: 0x005B7C9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE43 RID: 52803
		private int opl_p0;
	}
}
