using System;

namespace behaviac
{
	// Token: 0x0200390E RID: 14606
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node84 : Condition
	{
		// Token: 0x060159F7 RID: 88567 RVA: 0x006876CE File Offset: 0x00685ACE
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node84()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x060159F8 RID: 88568 RVA: 0x006876E4 File Offset: 0x00685AE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F38F RID: 62351
		private float opl_p0;
	}
}
