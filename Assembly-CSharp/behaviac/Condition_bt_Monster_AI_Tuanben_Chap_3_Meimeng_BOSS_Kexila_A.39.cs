using System;

namespace behaviac
{
	// Token: 0x0200390C RID: 14604
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node81 : Condition
	{
		// Token: 0x060159F3 RID: 88563 RVA: 0x006875DB File Offset: 0x006859DB
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node81()
		{
			this.opl_p0 = 21202;
		}

		// Token: 0x060159F4 RID: 88564 RVA: 0x006875F0 File Offset: 0x006859F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F38C RID: 62348
		private int opl_p0;
	}
}
