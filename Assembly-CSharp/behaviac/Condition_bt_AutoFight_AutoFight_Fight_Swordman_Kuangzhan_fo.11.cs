using System;

namespace behaviac
{
	// Token: 0x02002344 RID: 9028
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node26 : Condition
	{
		// Token: 0x06012FF6 RID: 77814 RVA: 0x0059E5CC File Offset: 0x0059C9CC
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node26()
		{
			this.opl_p0 = 0.27f;
		}

		// Token: 0x06012FF7 RID: 77815 RVA: 0x0059E5E0 File Offset: 0x0059C9E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA0E RID: 51726
		private float opl_p0;
	}
}
