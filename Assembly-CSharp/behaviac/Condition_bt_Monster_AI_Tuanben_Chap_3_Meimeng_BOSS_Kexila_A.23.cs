using System;

namespace behaviac
{
	// Token: 0x020038F3 RID: 14579
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node48 : Condition
	{
		// Token: 0x060159C3 RID: 88515 RVA: 0x00685DB6 File Offset: 0x006841B6
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node48()
		{
			this.opl_p0 = 0.23f;
		}

		// Token: 0x060159C4 RID: 88516 RVA: 0x00685DCC File Offset: 0x006841CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F36C RID: 62316
		private float opl_p0;
	}
}
