using System;

namespace behaviac
{
	// Token: 0x020038D7 RID: 14551
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node15 : Condition
	{
		// Token: 0x0601598B RID: 88459 RVA: 0x0068521F File Offset: 0x0068361F
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node15()
		{
			this.opl_p0 = 21208;
		}

		// Token: 0x0601598C RID: 88460 RVA: 0x00685234 File Offset: 0x00683634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F341 RID: 62273
		private int opl_p0;
	}
}
