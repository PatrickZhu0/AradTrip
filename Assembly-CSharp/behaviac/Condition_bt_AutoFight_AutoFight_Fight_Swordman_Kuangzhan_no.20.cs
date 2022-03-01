using System;

namespace behaviac
{
	// Token: 0x020023F9 RID: 9209
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node44 : Condition
	{
		// Token: 0x06013151 RID: 78161 RVA: 0x005A80F2 File Offset: 0x005A64F2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node44()
		{
			this.opl_p0 = 0.57f;
		}

		// Token: 0x06013152 RID: 78162 RVA: 0x005A8108 File Offset: 0x005A6508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB7B RID: 52091
		private float opl_p0;
	}
}
