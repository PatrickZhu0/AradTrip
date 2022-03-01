using System;

namespace behaviac
{
	// Token: 0x02003F6B RID: 16235
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node4 : Condition
	{
		// Token: 0x06016643 RID: 91715 RVA: 0x006C6123 File Offset: 0x006C4523
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x06016644 RID: 91716 RVA: 0x006C6144 File Offset: 0x006C4544
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE8E RID: 65166
		private BE_Target opl_p0;

		// Token: 0x0400FE8F RID: 65167
		private BE_Equal opl_p1;

		// Token: 0x0400FE90 RID: 65168
		private int opl_p2;
	}
}
