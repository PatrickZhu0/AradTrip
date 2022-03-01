using System;

namespace behaviac
{
	// Token: 0x02001F74 RID: 8052
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_foolish_Move_node5 : Condition
	{
		// Token: 0x06012889 RID: 75913 RVA: 0x0056D71D File Offset: 0x0056BB1D
		public Condition_bt_AutoFight_AutoFight_Fight_foolish_Move_node5()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601288A RID: 75914 RVA: 0x0056D730 File Offset: 0x0056BB30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C27E RID: 49790
		private float opl_p0;
	}
}
