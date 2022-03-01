using System;

namespace behaviac
{
	// Token: 0x02002224 RID: 8740
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node44 : Condition
	{
		// Token: 0x06012DD2 RID: 77266 RVA: 0x0058E725 File Offset: 0x0058CB25
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node44()
		{
			this.opl_p0 = 1701;
		}

		// Token: 0x06012DD3 RID: 77267 RVA: 0x0058E738 File Offset: 0x0058CB38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7CA RID: 51146
		private int opl_p0;
	}
}
