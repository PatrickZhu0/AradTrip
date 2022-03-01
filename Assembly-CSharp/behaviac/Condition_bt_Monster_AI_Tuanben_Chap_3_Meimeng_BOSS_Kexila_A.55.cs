using System;

namespace behaviac
{
	// Token: 0x02003923 RID: 14627
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node20 : Condition
	{
		// Token: 0x06015A21 RID: 88609 RVA: 0x00687FC2 File Offset: 0x006863C2
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node20()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06015A22 RID: 88610 RVA: 0x00687FD8 File Offset: 0x006863D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3B5 RID: 62389
		private float opl_p0;
	}
}
