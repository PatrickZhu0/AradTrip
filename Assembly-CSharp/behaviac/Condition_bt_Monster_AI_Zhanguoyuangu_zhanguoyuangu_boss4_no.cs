using System;

namespace behaviac
{
	// Token: 0x02003F30 RID: 16176
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node3 : Condition
	{
		// Token: 0x060165D1 RID: 91601 RVA: 0x006C403A File Offset: 0x006C243A
		public Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570232;
		}

		// Token: 0x060165D2 RID: 91602 RVA: 0x006C405C File Offset: 0x006C245C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDF5 RID: 65013
		private BE_Target opl_p0;

		// Token: 0x0400FDF6 RID: 65014
		private BE_Equal opl_p1;

		// Token: 0x0400FDF7 RID: 65015
		private int opl_p2;
	}
}
