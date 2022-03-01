using System;

namespace behaviac
{
	// Token: 0x02003911 RID: 14609
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node88 : Condition
	{
		// Token: 0x060159FD RID: 88573 RVA: 0x0068780A File Offset: 0x00685C0A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node88()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060159FE RID: 88574 RVA: 0x00687820 File Offset: 0x00685C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F393 RID: 62355
		private float opl_p0;
	}
}
