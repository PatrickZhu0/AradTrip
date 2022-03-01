using System;

namespace behaviac
{
	// Token: 0x02003FAF RID: 16303
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node47 : Condition
	{
		// Token: 0x060166C8 RID: 91848 RVA: 0x006C84F9 File Offset: 0x006C68F9
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node47()
		{
			this.opl_p0 = 5108;
		}

		// Token: 0x060166C9 RID: 91849 RVA: 0x006C850C File Offset: 0x006C690C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF1C RID: 65308
		private int opl_p0;
	}
}
