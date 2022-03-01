using System;

namespace behaviac
{
	// Token: 0x020029C9 RID: 10697
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node97 : Condition
	{
		// Token: 0x06013CC6 RID: 81094 RVA: 0x005EB80B File Offset: 0x005E9C0B
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node97()
		{
			this.opl_p0 = 1506;
		}

		// Token: 0x06013CC7 RID: 81095 RVA: 0x005EB820 File Offset: 0x005E9C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D736 RID: 55094
		private int opl_p0;
	}
}
