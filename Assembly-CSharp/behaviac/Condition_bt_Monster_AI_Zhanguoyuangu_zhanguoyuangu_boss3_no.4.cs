using System;

namespace behaviac
{
	// Token: 0x02003F28 RID: 16168
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node9 : Condition
	{
		// Token: 0x060165C2 RID: 91586 RVA: 0x006C3A92 File Offset: 0x006C1E92
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570232;
		}

		// Token: 0x060165C3 RID: 91587 RVA: 0x006C3AB4 File Offset: 0x006C1EB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDE2 RID: 64994
		private BE_Target opl_p0;

		// Token: 0x0400FDE3 RID: 64995
		private BE_Equal opl_p1;

		// Token: 0x0400FDE4 RID: 64996
		private int opl_p2;
	}
}
