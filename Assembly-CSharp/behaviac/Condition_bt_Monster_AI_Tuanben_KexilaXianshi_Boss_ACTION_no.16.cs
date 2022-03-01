using System;

namespace behaviac
{
	// Token: 0x02003A49 RID: 14921
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node95 : Condition
	{
		// Token: 0x06015C5B RID: 89179 RVA: 0x00693843 File Offset: 0x00691C43
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node95()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570036;
		}

		// Token: 0x06015C5C RID: 89180 RVA: 0x00693864 File Offset: 0x00691C64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F57F RID: 62847
		private BE_Target opl_p0;

		// Token: 0x0400F580 RID: 62848
		private BE_Equal opl_p1;

		// Token: 0x0400F581 RID: 62849
		private int opl_p2;
	}
}
