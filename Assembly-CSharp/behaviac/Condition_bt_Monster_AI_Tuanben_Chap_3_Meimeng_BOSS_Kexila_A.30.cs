using System;

namespace behaviac
{
	// Token: 0x020038FD RID: 14589
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node58 : Condition
	{
		// Token: 0x060159D7 RID: 88535 RVA: 0x006861B3 File Offset: 0x006845B3
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node58()
		{
			this.opl_p0 = 21205;
		}

		// Token: 0x060159D8 RID: 88536 RVA: 0x006861C8 File Offset: 0x006845C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F379 RID: 62329
		private int opl_p0;
	}
}
