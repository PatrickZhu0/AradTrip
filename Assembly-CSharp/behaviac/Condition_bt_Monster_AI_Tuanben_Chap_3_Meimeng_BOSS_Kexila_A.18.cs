using System;

namespace behaviac
{
	// Token: 0x020038EB RID: 14571
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node38 : Condition
	{
		// Token: 0x060159B3 RID: 88499 RVA: 0x00685A4B File Offset: 0x00683E4B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node38()
		{
			this.opl_p0 = 21209;
		}

		// Token: 0x060159B4 RID: 88500 RVA: 0x00685A60 File Offset: 0x00683E60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F361 RID: 62305
		private int opl_p0;
	}
}
