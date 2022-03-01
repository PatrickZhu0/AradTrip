using System;

namespace behaviac
{
	// Token: 0x02003FD9 RID: 16345
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6 : Condition
	{
		// Token: 0x0601671A RID: 91930 RVA: 0x006CA86E File Offset: 0x006C8C6E
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601671B RID: 91931 RVA: 0x006CA884 File Offset: 0x006C8C84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF6C RID: 65388
		private float opl_p0;
	}
}
