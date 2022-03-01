using System;

namespace behaviac
{
	// Token: 0x02002381 RID: 9089
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node44 : Condition
	{
		// Token: 0x06013069 RID: 77929 RVA: 0x005A0E02 File Offset: 0x0059F202
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node44()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x0601306A RID: 77930 RVA: 0x005A0E18 File Offset: 0x0059F218
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA7E RID: 51838
		private float opl_p0;
	}
}
