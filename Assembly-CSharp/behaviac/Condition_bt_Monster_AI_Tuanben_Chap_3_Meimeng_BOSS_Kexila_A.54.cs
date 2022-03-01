using System;

namespace behaviac
{
	// Token: 0x02003921 RID: 14625
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node17 : Condition
	{
		// Token: 0x06015A1D RID: 88605 RVA: 0x00687ECF File Offset: 0x006862CF
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node17()
		{
			this.opl_p0 = 21457;
		}

		// Token: 0x06015A1E RID: 88606 RVA: 0x00687EE4 File Offset: 0x006862E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3B2 RID: 62386
		private int opl_p0;
	}
}
