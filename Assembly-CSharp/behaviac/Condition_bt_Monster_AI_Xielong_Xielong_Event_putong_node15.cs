using System;

namespace behaviac
{
	// Token: 0x02003E48 RID: 15944
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node15 : Condition
	{
		// Token: 0x06016415 RID: 91157 RVA: 0x006BA847 File Offset: 0x006B8C47
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node15()
		{
			this.opl_p0 = 7082;
		}

		// Token: 0x06016416 RID: 91158 RVA: 0x006BA85C File Offset: 0x006B8C5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC6B RID: 64619
		private int opl_p0;
	}
}
