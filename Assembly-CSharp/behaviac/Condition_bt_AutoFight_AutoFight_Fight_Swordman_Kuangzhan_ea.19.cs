using System;

namespace behaviac
{
	// Token: 0x0200231F RID: 8991
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node40 : Condition
	{
		// Token: 0x06012FB1 RID: 77745 RVA: 0x0059C777 File Offset: 0x0059AB77
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x06012FB2 RID: 77746 RVA: 0x0059C78C File Offset: 0x0059AB8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9C9 RID: 51657
		private int opl_p0;
	}
}
