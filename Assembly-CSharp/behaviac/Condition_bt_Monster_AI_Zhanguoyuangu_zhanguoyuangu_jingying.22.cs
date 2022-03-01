using System;

namespace behaviac
{
	// Token: 0x02003F6F RID: 16239
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node9 : Condition
	{
		// Token: 0x0601664B RID: 91723 RVA: 0x006C6246 File Offset: 0x006C4646
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying4_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570217;
		}

		// Token: 0x0601664C RID: 91724 RVA: 0x006C6268 File Offset: 0x006C4668
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE96 RID: 65174
		private BE_Target opl_p0;

		// Token: 0x0400FE97 RID: 65175
		private BE_Equal opl_p1;

		// Token: 0x0400FE98 RID: 65176
		private int opl_p2;
	}
}
