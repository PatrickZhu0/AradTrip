using System;

namespace behaviac
{
	// Token: 0x020028A2 RID: 10402
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node13 : Condition
	{
		// Token: 0x06013A7E RID: 80510 RVA: 0x005DEA8B File Offset: 0x005DCE8B
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013A7F RID: 80511 RVA: 0x005DEAA0 File Offset: 0x005DCEA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4DA RID: 54490
		private int opl_p0;
	}
}
