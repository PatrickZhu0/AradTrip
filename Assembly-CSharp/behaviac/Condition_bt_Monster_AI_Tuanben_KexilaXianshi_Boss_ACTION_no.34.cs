using System;

namespace behaviac
{
	// Token: 0x02003A62 RID: 14946
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node51 : Condition
	{
		// Token: 0x06015C8D RID: 89229 RVA: 0x006942E5 File Offset: 0x006926E5
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node51()
		{
			this.opl_p0 = 21062;
		}

		// Token: 0x06015C8E RID: 89230 RVA: 0x006942F8 File Offset: 0x006926F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5BE RID: 62910
		private int opl_p0;
	}
}
