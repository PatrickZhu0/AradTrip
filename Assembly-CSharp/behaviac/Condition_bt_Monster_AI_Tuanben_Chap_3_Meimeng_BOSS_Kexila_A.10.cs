using System;

namespace behaviac
{
	// Token: 0x020038DF RID: 14559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node24 : Condition
	{
		// Token: 0x0601599B RID: 88475 RVA: 0x0068558A File Offset: 0x0068398A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node24()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x0601599C RID: 88476 RVA: 0x006855A0 File Offset: 0x006839A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F34C RID: 62284
		private float opl_p0;
	}
}
