using System;

namespace behaviac
{
	// Token: 0x02002323 RID: 8995
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node45 : Condition
	{
		// Token: 0x06012FB9 RID: 77753 RVA: 0x0059C92D File Offset: 0x0059AD2D
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node45()
		{
			this.opl_p0 = 1604;
		}

		// Token: 0x06012FBA RID: 77754 RVA: 0x0059C940 File Offset: 0x0059AD40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9D1 RID: 51665
		private int opl_p0;
	}
}
