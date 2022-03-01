using System;

namespace behaviac
{
	// Token: 0x020022F8 RID: 8952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node10 : Condition
	{
		// Token: 0x06012F69 RID: 77673 RVA: 0x0059AAAD File Offset: 0x00598EAD
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node10()
		{
			this.opl_p0 = 1909;
		}

		// Token: 0x06012F6A RID: 77674 RVA: 0x0059AAC0 File Offset: 0x00598EC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C981 RID: 51585
		private int opl_p0;
	}
}
