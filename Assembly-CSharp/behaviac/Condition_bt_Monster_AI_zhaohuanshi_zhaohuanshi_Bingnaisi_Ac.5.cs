using System;

namespace behaviac
{
	// Token: 0x02003F7E RID: 16254
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node11 : Condition
	{
		// Token: 0x06016668 RID: 91752 RVA: 0x006C6B2F File Offset: 0x006C4F2F
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node11()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016669 RID: 91753 RVA: 0x006C6B64 File Offset: 0x006C4F64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEBC RID: 65212
		private int opl_p0;

		// Token: 0x0400FEBD RID: 65213
		private int opl_p1;

		// Token: 0x0400FEBE RID: 65214
		private int opl_p2;

		// Token: 0x0400FEBF RID: 65215
		private int opl_p3;
	}
}
