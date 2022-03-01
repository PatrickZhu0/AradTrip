using System;

namespace behaviac
{
	// Token: 0x02003F87 RID: 16263
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node5 : Condition
	{
		// Token: 0x06016679 RID: 91769 RVA: 0x006C72B7 File Offset: 0x006C56B7
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_DestinationSelect_node5()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601667A RID: 91770 RVA: 0x006C72EC File Offset: 0x006C56EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FECC RID: 65228
		private int opl_p0;

		// Token: 0x0400FECD RID: 65229
		private int opl_p1;

		// Token: 0x0400FECE RID: 65230
		private int opl_p2;

		// Token: 0x0400FECF RID: 65231
		private int opl_p3;
	}
}
