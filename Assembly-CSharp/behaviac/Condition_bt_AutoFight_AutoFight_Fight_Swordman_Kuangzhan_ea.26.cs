using System;

namespace behaviac
{
	// Token: 0x02002328 RID: 9000
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node50 : Condition
	{
		// Token: 0x06012FC3 RID: 77763 RVA: 0x0059CB9B File Offset: 0x0059AF9B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node50()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x06012FC4 RID: 77764 RVA: 0x0059CBB0 File Offset: 0x0059AFB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9DC RID: 51676
		private int opl_p0;
	}
}
