using System;

namespace behaviac
{
	// Token: 0x020038DC RID: 14556
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node20 : Condition
	{
		// Token: 0x06015995 RID: 88469 RVA: 0x0068544E File Offset: 0x0068384E
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_node20()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06015996 RID: 88470 RVA: 0x00685464 File Offset: 0x00683864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F348 RID: 62280
		private float opl_p0;
	}
}
