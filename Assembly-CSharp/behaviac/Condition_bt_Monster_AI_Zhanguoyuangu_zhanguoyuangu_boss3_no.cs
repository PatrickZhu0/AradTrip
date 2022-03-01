using System;

namespace behaviac
{
	// Token: 0x02003F23 RID: 16163
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node3 : Condition
	{
		// Token: 0x060165B8 RID: 91576 RVA: 0x006C390E File Offset: 0x006C1D0E
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570232;
		}

		// Token: 0x060165B9 RID: 91577 RVA: 0x006C3930 File Offset: 0x006C1D30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDD7 RID: 64983
		private BE_Target opl_p0;

		// Token: 0x0400FDD8 RID: 64984
		private BE_Equal opl_p1;

		// Token: 0x0400FDD9 RID: 64985
		private int opl_p2;
	}
}
