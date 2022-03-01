using System;

namespace behaviac
{
	// Token: 0x0200233B RID: 9019
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node13 : Condition
	{
		// Token: 0x06012FE6 RID: 77798 RVA: 0x0059E17F File Offset: 0x0059C57F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012FE7 RID: 77799 RVA: 0x0059E194 File Offset: 0x0059C594
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9FF RID: 51711
		private int opl_p0;
	}
}
