using System;

namespace behaviac
{
	// Token: 0x0200220C RID: 8716
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node17 : Condition
	{
		// Token: 0x06012DA2 RID: 77218 RVA: 0x0058CE8D File Offset: 0x0058B28D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node17()
		{
			this.opl_p0 = 1709;
		}

		// Token: 0x06012DA3 RID: 77219 RVA: 0x0058CEA0 File Offset: 0x0058B2A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C796 RID: 51094
		private int opl_p0;
	}
}
