using System;

namespace behaviac
{
	// Token: 0x02003F3E RID: 16190
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node4 : Condition
	{
		// Token: 0x060165EC RID: 91628 RVA: 0x006C47C7 File Offset: 0x006C2BC7
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying1_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x060165ED RID: 91629 RVA: 0x006C47E8 File Offset: 0x006C2BE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FE16 RID: 65046
		private BE_Target opl_p0;

		// Token: 0x0400FE17 RID: 65047
		private BE_Equal opl_p1;

		// Token: 0x0400FE18 RID: 65048
		private int opl_p2;
	}
}
