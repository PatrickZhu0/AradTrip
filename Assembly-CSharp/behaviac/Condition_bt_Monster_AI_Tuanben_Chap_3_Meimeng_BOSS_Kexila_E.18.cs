using System;

namespace behaviac
{
	// Token: 0x02003978 RID: 14712
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node16 : Condition
	{
		// Token: 0x06015AC7 RID: 88775 RVA: 0x0068B837 File Offset: 0x00689C37
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node16()
		{
			this.opl_p0 = 21206;
		}

		// Token: 0x06015AC8 RID: 88776 RVA: 0x0068B84C File Offset: 0x00689C4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F46E RID: 62574
		private int opl_p0;
	}
}
