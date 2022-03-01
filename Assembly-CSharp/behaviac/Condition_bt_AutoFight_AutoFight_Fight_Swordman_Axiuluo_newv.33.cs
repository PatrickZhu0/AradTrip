using System;

namespace behaviac
{
	// Token: 0x0200222C RID: 8748
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node27 : Condition
	{
		// Token: 0x06012DE2 RID: 77282 RVA: 0x0058EB2D File Offset: 0x0058CF2D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node27()
		{
			this.opl_p0 = 1707;
		}

		// Token: 0x06012DE3 RID: 77283 RVA: 0x0058EB40 File Offset: 0x0058CF40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7E2 RID: 51170
		private int opl_p0;
	}
}
