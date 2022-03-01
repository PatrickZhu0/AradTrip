using System;

namespace behaviac
{
	// Token: 0x0200387B RID: 14459
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node28 : Condition
	{
		// Token: 0x060158DA RID: 88282 RVA: 0x006814DE File Offset: 0x0067F8DE
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_Hard_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060158DB RID: 88283 RVA: 0x006814F4 File Offset: 0x0067F8F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F27A RID: 62074
		private float opl_p0;
	}
}
