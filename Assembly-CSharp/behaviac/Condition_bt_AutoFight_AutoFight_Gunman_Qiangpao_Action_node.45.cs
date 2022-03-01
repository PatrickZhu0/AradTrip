using System;

namespace behaviac
{
	// Token: 0x02002679 RID: 9849
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node9 : Condition
	{
		// Token: 0x06013637 RID: 79415 RVA: 0x005C4E52 File Offset: 0x005C3252
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node9()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013638 RID: 79416 RVA: 0x005C4E68 File Offset: 0x005C3268
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D089 RID: 53385
		private float opl_p0;
	}
}
