using System;

namespace behaviac
{
	// Token: 0x020039E9 RID: 14825
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node14 : Condition
	{
		// Token: 0x06015BA2 RID: 88994 RVA: 0x0068FA4E File Offset: 0x0068DE4E
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node14()
		{
			this.opl_p0 = 21072;
		}

		// Token: 0x06015BA3 RID: 88995 RVA: 0x0068FA64 File Offset: 0x0068DE64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4E2 RID: 62690
		private int opl_p0;
	}
}
