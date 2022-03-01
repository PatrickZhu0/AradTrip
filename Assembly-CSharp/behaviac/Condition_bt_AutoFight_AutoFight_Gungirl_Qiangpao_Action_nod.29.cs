using System;

namespace behaviac
{
	// Token: 0x02002539 RID: 9529
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node35 : Condition
	{
		// Token: 0x060133BB RID: 78779 RVA: 0x005B6BD1 File Offset: 0x005B4FD1
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node35()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060133BC RID: 78780 RVA: 0x005B6BE4 File Offset: 0x005B4FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDE3 RID: 52707
		private float opl_p0;
	}
}
