using System;

namespace behaviac
{
	// Token: 0x02003F1C RID: 16156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node8 : Condition
	{
		// Token: 0x060165AB RID: 91563 RVA: 0x006C33C7 File Offset: 0x006C17C7
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x060165AC RID: 91564 RVA: 0x006C33E8 File Offset: 0x006C17E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDC7 RID: 64967
		private BE_Target opl_p0;

		// Token: 0x0400FDC8 RID: 64968
		private BE_Equal opl_p1;

		// Token: 0x0400FDC9 RID: 64969
		private int opl_p2;
	}
}
