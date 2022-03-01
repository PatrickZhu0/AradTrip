using System;

namespace behaviac
{
	// Token: 0x020022B5 RID: 8885
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node99 : Condition
	{
		// Token: 0x06012EE5 RID: 77541 RVA: 0x005962A1 File Offset: 0x005946A1
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node99()
		{
			this.opl_p0 = 1912;
		}

		// Token: 0x06012EE6 RID: 77542 RVA: 0x005962B4 File Offset: 0x005946B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8F8 RID: 51448
		private int opl_p0;
	}
}
