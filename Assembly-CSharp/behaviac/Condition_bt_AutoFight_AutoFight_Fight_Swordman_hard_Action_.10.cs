using System;

namespace behaviac
{
	// Token: 0x020022A4 RID: 8868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node21 : Condition
	{
		// Token: 0x06012EC4 RID: 77508 RVA: 0x005952EB File Offset: 0x005936EB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node21()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012EC5 RID: 77509 RVA: 0x00595300 File Offset: 0x00593700
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8CE RID: 51406
		private int opl_p0;
	}
}
