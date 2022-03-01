using System;

namespace behaviac
{
	// Token: 0x02003C6A RID: 15466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node85 : Condition
	{
		// Token: 0x0601607B RID: 90235 RVA: 0x006A895B File Offset: 0x006A6D5B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node85()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570033;
		}

		// Token: 0x0601607C RID: 90236 RVA: 0x006A897C File Offset: 0x006A6D7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8FE RID: 63742
		private BE_Target opl_p0;

		// Token: 0x0400F8FF RID: 63743
		private BE_Equal opl_p1;

		// Token: 0x0400F900 RID: 63744
		private int opl_p2;
	}
}
