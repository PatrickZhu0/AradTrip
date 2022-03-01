using System;

namespace behaviac
{
	// Token: 0x0200236F RID: 9071
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node19 : Condition
	{
		// Token: 0x06013047 RID: 77895 RVA: 0x005A06D4 File Offset: 0x0059EAD4
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node19()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06013048 RID: 77896 RVA: 0x005A06E8 File Offset: 0x0059EAE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA5F RID: 51807
		private float opl_p0;
	}
}
