using System;

namespace behaviac
{
	// Token: 0x02003A57 RID: 14935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node46 : Condition
	{
		// Token: 0x06015C77 RID: 89207 RVA: 0x00693DE1 File Offset: 0x006921E1
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node46()
		{
			this.opl_p0 = 21052;
		}

		// Token: 0x06015C78 RID: 89208 RVA: 0x00693DF4 File Offset: 0x006921F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5A3 RID: 62883
		private int opl_p0;
	}
}
