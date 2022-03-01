using System;

namespace behaviac
{
	// Token: 0x02003F5B RID: 16219
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node3 : Condition
	{
		// Token: 0x06016624 RID: 91684 RVA: 0x006C584C File Offset: 0x006C3C4C
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570217;
		}

		// Token: 0x06016625 RID: 91685 RVA: 0x006C5870 File Offset: 0x006C3C70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE63 RID: 65123
		private BE_Target opl_p0;

		// Token: 0x0400FE64 RID: 65124
		private BE_Equal opl_p1;

		// Token: 0x0400FE65 RID: 65125
		private int opl_p2;
	}
}
