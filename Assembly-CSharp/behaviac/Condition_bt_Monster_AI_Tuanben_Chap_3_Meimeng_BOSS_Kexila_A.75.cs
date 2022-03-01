using System;

namespace behaviac
{
	// Token: 0x02003941 RID: 14657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node56 : Condition
	{
		// Token: 0x06015A5D RID: 88669 RVA: 0x00688C6A File Offset: 0x0068706A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node56()
		{
			this.opl_p0 = 0.43f;
		}

		// Token: 0x06015A5E RID: 88670 RVA: 0x00688C80 File Offset: 0x00687080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3E9 RID: 62441
		private float opl_p0;
	}
}
