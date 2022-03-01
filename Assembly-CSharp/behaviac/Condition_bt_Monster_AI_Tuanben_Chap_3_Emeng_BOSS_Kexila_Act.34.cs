using System;

namespace behaviac
{
	// Token: 0x0200386B RID: 14443
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node50 : Condition
	{
		// Token: 0x060158BA RID: 88250 RVA: 0x00680E6B File Offset: 0x0067F26B
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node50()
		{
			this.opl_p0 = 21228;
		}

		// Token: 0x060158BB RID: 88251 RVA: 0x00680E80 File Offset: 0x0067F280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F263 RID: 62051
		private int opl_p0;
	}
}
