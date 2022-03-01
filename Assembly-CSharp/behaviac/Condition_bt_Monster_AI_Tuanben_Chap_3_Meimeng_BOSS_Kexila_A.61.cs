using System;

namespace behaviac
{
	// Token: 0x0200392C RID: 14636
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node32 : Condition
	{
		// Token: 0x06015A33 RID: 88627 RVA: 0x00688376 File Offset: 0x00686776
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node32()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015A34 RID: 88628 RVA: 0x0068838C File Offset: 0x0068678C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3C1 RID: 62401
		private float opl_p0;
	}
}
