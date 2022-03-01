using System;

namespace behaviac
{
	// Token: 0x0200255D RID: 9565
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node101 : Condition
	{
		// Token: 0x06013403 RID: 78851 RVA: 0x005B7B2D File Offset: 0x005B5F2D
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node101()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013404 RID: 78852 RVA: 0x005B7B40 File Offset: 0x005B5F40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE2B RID: 52779
		private float opl_p0;
	}
}
