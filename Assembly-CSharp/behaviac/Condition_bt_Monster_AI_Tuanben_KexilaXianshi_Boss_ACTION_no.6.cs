using System;

namespace behaviac
{
	// Token: 0x02003A3C RID: 14908
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node84 : Condition
	{
		// Token: 0x06015C41 RID: 89153 RVA: 0x006932F3 File Offset: 0x006916F3
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node84()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570105;
		}

		// Token: 0x06015C42 RID: 89154 RVA: 0x00693314 File Offset: 0x00691714
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F55C RID: 62812
		private BE_Target opl_p0;

		// Token: 0x0400F55D RID: 62813
		private BE_Equal opl_p1;

		// Token: 0x0400F55E RID: 62814
		private int opl_p2;
	}
}
