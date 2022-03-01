using System;

namespace behaviac
{
	// Token: 0x02003915 RID: 14613
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node93 : Condition
	{
		// Token: 0x06015A05 RID: 88581 RVA: 0x0068798F File Offset: 0x00685D8F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node93()
		{
			this.opl_p0 = 21205;
		}

		// Token: 0x06015A06 RID: 88582 RVA: 0x006879A4 File Offset: 0x00685DA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F398 RID: 62360
		private int opl_p0;
	}
}
