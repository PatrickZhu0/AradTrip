using System;

namespace behaviac
{
	// Token: 0x020038D9 RID: 14553
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node13 : Condition
	{
		// Token: 0x0601598F RID: 88463 RVA: 0x00685312 File Offset: 0x00683712
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node13()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06015990 RID: 88464 RVA: 0x00685328 File Offset: 0x00683728
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F344 RID: 62276
		private float opl_p0;
	}
}
