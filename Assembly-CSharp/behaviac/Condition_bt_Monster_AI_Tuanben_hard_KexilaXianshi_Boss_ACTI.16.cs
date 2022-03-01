using System;

namespace behaviac
{
	// Token: 0x02003C7B RID: 15483
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node95 : Condition
	{
		// Token: 0x0601609D RID: 90269 RVA: 0x006A902B File Offset: 0x006A742B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node95()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570036;
		}

		// Token: 0x0601609E RID: 90270 RVA: 0x006A904C File Offset: 0x006A744C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F92D RID: 63789
		private BE_Target opl_p0;

		// Token: 0x0400F92E RID: 63790
		private BE_Equal opl_p1;

		// Token: 0x0400F92F RID: 63791
		private int opl_p2;
	}
}
