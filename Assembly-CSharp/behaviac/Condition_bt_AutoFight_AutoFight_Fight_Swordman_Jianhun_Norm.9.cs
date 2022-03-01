using System;

namespace behaviac
{
	// Token: 0x020022F4 RID: 8948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node5 : Condition
	{
		// Token: 0x06012F61 RID: 77665 RVA: 0x0059A733 File Offset: 0x00598B33
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node5()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012F62 RID: 77666 RVA: 0x0059A748 File Offset: 0x00598B48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C979 RID: 51577
		private int opl_p0;
	}
}
