using System;

namespace behaviac
{
	// Token: 0x02002564 RID: 9572
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node113 : Condition
	{
		// Token: 0x06013411 RID: 78865 RVA: 0x005B7E1A File Offset: 0x005B621A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node113()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013412 RID: 78866 RVA: 0x005B7E30 File Offset: 0x005B6230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE37 RID: 52791
		private float opl_p0;
	}
}
