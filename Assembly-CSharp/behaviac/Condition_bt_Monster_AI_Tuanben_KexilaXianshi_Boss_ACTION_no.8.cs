using System;

namespace behaviac
{
	// Token: 0x02003A40 RID: 14912
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node77 : Condition
	{
		// Token: 0x06015C49 RID: 89161 RVA: 0x006934AD File Offset: 0x006918AD
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node77()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x06015C4A RID: 89162 RVA: 0x006934D0 File Offset: 0x006918D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F567 RID: 62823
		private BE_Target opl_p0;

		// Token: 0x0400F568 RID: 62824
		private BE_Equal opl_p1;

		// Token: 0x0400F569 RID: 62825
		private int opl_p2;
	}
}
