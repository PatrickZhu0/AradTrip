using System;

namespace behaviac
{
	// Token: 0x02002310 RID: 8976
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node21 : Condition
	{
		// Token: 0x06012F95 RID: 77717 RVA: 0x0059C183 File Offset: 0x0059A583
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node21()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x06012F96 RID: 77718 RVA: 0x0059C198 File Offset: 0x0059A598
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9AE RID: 51630
		private int opl_p0;
	}
}
