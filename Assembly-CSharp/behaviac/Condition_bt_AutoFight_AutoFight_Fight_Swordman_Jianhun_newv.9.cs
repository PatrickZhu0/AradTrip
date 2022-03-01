using System;

namespace behaviac
{
	// Token: 0x020022B9 RID: 8889
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node25 : Condition
	{
		// Token: 0x06012EED RID: 77549 RVA: 0x00596455 File Offset: 0x00594855
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node25()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06012EEE RID: 77550 RVA: 0x00596468 File Offset: 0x00594868
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C900 RID: 51456
		private int opl_p0;
	}
}
