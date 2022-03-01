using System;

namespace behaviac
{
	// Token: 0x02002541 RID: 9537
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node69 : Condition
	{
		// Token: 0x060133CB RID: 78795 RVA: 0x005B6F41 File Offset: 0x005B5341
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node69()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060133CC RID: 78796 RVA: 0x005B6F54 File Offset: 0x005B5354
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDF3 RID: 52723
		private float opl_p0;
	}
}
