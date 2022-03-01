using System;

namespace behaviac
{
	// Token: 0x0200393B RID: 14651
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node48 : Condition
	{
		// Token: 0x06015A51 RID: 88657 RVA: 0x006889F2 File Offset: 0x00686DF2
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Action_Hard_node48()
		{
			this.opl_p0 = 0.23f;
		}

		// Token: 0x06015A52 RID: 88658 RVA: 0x00688A08 File Offset: 0x00686E08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F3E1 RID: 62433
		private float opl_p0;
	}
}
