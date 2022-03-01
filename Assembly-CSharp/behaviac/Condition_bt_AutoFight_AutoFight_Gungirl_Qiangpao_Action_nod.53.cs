using System;

namespace behaviac
{
	// Token: 0x02002559 RID: 9561
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node97 : Condition
	{
		// Token: 0x060133FB RID: 78843 RVA: 0x005B7979 File Offset: 0x005B5D79
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node97()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060133FC RID: 78844 RVA: 0x005B798C File Offset: 0x005B5D8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE23 RID: 52771
		private float opl_p0;
	}
}
