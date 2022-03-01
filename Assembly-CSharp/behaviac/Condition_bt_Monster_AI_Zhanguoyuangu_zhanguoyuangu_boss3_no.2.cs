using System;

namespace behaviac
{
	// Token: 0x02003F24 RID: 16164
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node4 : Condition
	{
		// Token: 0x060165BA RID: 91578 RVA: 0x006C396F File Offset: 0x006C1D6F
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss3_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570231;
		}

		// Token: 0x060165BB RID: 91579 RVA: 0x006C3990 File Offset: 0x006C1D90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDDA RID: 64986
		private BE_Target opl_p0;

		// Token: 0x0400FDDB RID: 64987
		private BE_Equal opl_p1;

		// Token: 0x0400FDDC RID: 64988
		private int opl_p2;
	}
}
