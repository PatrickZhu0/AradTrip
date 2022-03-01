using System;

namespace behaviac
{
	// Token: 0x02002340 RID: 9024
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node21 : Condition
	{
		// Token: 0x06012FEF RID: 77807 RVA: 0x0059E44F File Offset: 0x0059C84F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node21()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x06012FF0 RID: 77808 RVA: 0x0059E464 File Offset: 0x0059C864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA07 RID: 51719
		private int opl_p0;
	}
}
