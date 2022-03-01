using System;

namespace behaviac
{
	// Token: 0x02003F42 RID: 16194
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node9 : Condition
	{
		// Token: 0x060165F4 RID: 91636 RVA: 0x006C48EA File Offset: 0x006C2CEA
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570217;
		}

		// Token: 0x060165F5 RID: 91637 RVA: 0x006C490C File Offset: 0x006C2D0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE1E RID: 65054
		private BE_Target opl_p0;

		// Token: 0x0400FE1F RID: 65055
		private BE_Equal opl_p1;

		// Token: 0x0400FE20 RID: 65056
		private int opl_p2;
	}
}
