using System;

namespace behaviac
{
	// Token: 0x02002379 RID: 9081
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node33 : Condition
	{
		// Token: 0x06013059 RID: 77913 RVA: 0x005A0AB4 File Offset: 0x0059EEB4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node33()
		{
			this.opl_p0 = 0.71f;
		}

		// Token: 0x0601305A RID: 77914 RVA: 0x005A0AC8 File Offset: 0x0059EEC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA6F RID: 51823
		private float opl_p0;
	}
}
