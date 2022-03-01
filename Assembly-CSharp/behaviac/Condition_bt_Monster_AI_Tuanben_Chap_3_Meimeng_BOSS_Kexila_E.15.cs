using System;

namespace behaviac
{
	// Token: 0x02003971 RID: 14705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node7 : Condition
	{
		// Token: 0x06015AB9 RID: 88761 RVA: 0x0068B5E3 File Offset: 0x006899E3
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node7()
		{
			this.opl_p0 = 21473;
		}

		// Token: 0x06015ABA RID: 88762 RVA: 0x0068B5F8 File Offset: 0x006899F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F461 RID: 62561
		private int opl_p0;
	}
}
