using System;

namespace behaviac
{
	// Token: 0x020022F0 RID: 8944
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node99 : Condition
	{
		// Token: 0x06012F59 RID: 77657 RVA: 0x0059A581 File Offset: 0x00598981
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node99()
		{
			this.opl_p0 = 1912;
		}

		// Token: 0x06012F5A RID: 77658 RVA: 0x0059A594 File Offset: 0x00598994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C971 RID: 51569
		private int opl_p0;
	}
}
