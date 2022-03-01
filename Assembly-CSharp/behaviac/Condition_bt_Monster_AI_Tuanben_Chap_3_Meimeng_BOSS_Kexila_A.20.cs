using System;

namespace behaviac
{
	// Token: 0x020038EE RID: 14574
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node42 : Condition
	{
		// Token: 0x060159B9 RID: 88505 RVA: 0x00685B87 File Offset: 0x00683F87
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node42()
		{
			this.opl_p0 = 21208;
		}

		// Token: 0x060159BA RID: 88506 RVA: 0x00685B9C File Offset: 0x00683F9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F365 RID: 62309
		private int opl_p0;
	}
}
