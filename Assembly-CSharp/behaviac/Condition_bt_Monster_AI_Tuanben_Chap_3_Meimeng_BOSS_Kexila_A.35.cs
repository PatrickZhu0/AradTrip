using System;

namespace behaviac
{
	// Token: 0x02003906 RID: 14598
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node73 : Condition
	{
		// Token: 0x060159E7 RID: 88551 RVA: 0x00687363 File Offset: 0x00685763
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node73()
		{
			this.opl_p0 = 21208;
		}

		// Token: 0x060159E8 RID: 88552 RVA: 0x00687378 File Offset: 0x00685778
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F384 RID: 62340
		private int opl_p0;
	}
}
