using System;

namespace behaviac
{
	// Token: 0x02002339 RID: 9017
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node11 : Condition
	{
		// Token: 0x06012FE2 RID: 77794 RVA: 0x0059E0DC File Offset: 0x0059C4DC
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node11()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012FE3 RID: 77795 RVA: 0x0059E0F0 File Offset: 0x0059C4F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9FB RID: 51707
		private float opl_p0;
	}
}
