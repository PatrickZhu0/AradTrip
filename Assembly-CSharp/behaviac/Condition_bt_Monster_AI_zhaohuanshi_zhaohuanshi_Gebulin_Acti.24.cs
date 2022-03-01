using System;

namespace behaviac
{
	// Token: 0x02003FAB RID: 16299
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node42 : Condition
	{
		// Token: 0x060166C0 RID: 91840 RVA: 0x006C8345 File Offset: 0x006C6745
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node42()
		{
			this.opl_p0 = 5109;
		}

		// Token: 0x060166C1 RID: 91841 RVA: 0x006C8358 File Offset: 0x006C6758
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF14 RID: 65300
		private int opl_p0;
	}
}
