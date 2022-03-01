using System;

namespace behaviac
{
	// Token: 0x0200225C RID: 8796
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node27 : Condition
	{
		// Token: 0x06012E40 RID: 77376 RVA: 0x005919D1 File Offset: 0x0058FDD1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node27()
		{
			this.opl_p0 = 1707;
		}

		// Token: 0x06012E41 RID: 77377 RVA: 0x005919E4 File Offset: 0x0058FDE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C84E RID: 51278
		private int opl_p0;
	}
}
