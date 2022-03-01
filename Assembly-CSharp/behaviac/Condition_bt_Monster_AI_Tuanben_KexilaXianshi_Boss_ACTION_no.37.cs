using System;

namespace behaviac
{
	// Token: 0x02003A67 RID: 14951
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node37 : Condition
	{
		// Token: 0x06015C97 RID: 89239 RVA: 0x00694542 File Offset: 0x00692942
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node37()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570036;
		}

		// Token: 0x06015C98 RID: 89240 RVA: 0x00694564 File Offset: 0x00692964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5C8 RID: 62920
		private BE_Target opl_p0;

		// Token: 0x0400F5C9 RID: 62921
		private BE_Equal opl_p1;

		// Token: 0x0400F5CA RID: 62922
		private int opl_p2;
	}
}
