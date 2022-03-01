using System;

namespace behaviac
{
	// Token: 0x02003ECD RID: 16077
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node20 : Condition
	{
		// Token: 0x06016517 RID: 91415 RVA: 0x006C01DB File Offset: 0x006BE5DB
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node20()
		{
			this.opl_p0 = 7297;
		}

		// Token: 0x06016518 RID: 91416 RVA: 0x006C01F0 File Offset: 0x006BE5F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD4C RID: 64844
		private int opl_p0;
	}
}
