using System;

namespace behaviac
{
	// Token: 0x02003A52 RID: 14930
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node14 : Condition
	{
		// Token: 0x06015C6D RID: 89197 RVA: 0x00693B9A File Offset: 0x00691F9A
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node14()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570033;
		}

		// Token: 0x06015C6E RID: 89198 RVA: 0x00693BBC File Offset: 0x00691FBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F595 RID: 62869
		private BE_Target opl_p0;

		// Token: 0x0400F596 RID: 62870
		private BE_Equal opl_p1;

		// Token: 0x0400F597 RID: 62871
		private int opl_p2;
	}
}
