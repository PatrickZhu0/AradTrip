using System;

namespace behaviac
{
	// Token: 0x02003870 RID: 14448
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node13 : Condition
	{
		// Token: 0x060158C4 RID: 88260 RVA: 0x0068109A File Offset: 0x0067F49A
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node13()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060158C5 RID: 88261 RVA: 0x006810B0 File Offset: 0x0067F4B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F26A RID: 62058
		private float opl_p0;
	}
}
