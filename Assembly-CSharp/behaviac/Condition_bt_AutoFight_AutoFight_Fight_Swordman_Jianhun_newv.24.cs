using System;

namespace behaviac
{
	// Token: 0x020022CD RID: 8909
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node10 : Condition
	{
		// Token: 0x06012F15 RID: 77589 RVA: 0x00597C35 File Offset: 0x00596035
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node10()
		{
			this.opl_p0 = 1909;
		}

		// Token: 0x06012F16 RID: 77590 RVA: 0x00597C48 File Offset: 0x00596048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C928 RID: 51496
		private int opl_p0;
	}
}
