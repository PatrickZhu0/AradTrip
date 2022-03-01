using System;

namespace behaviac
{
	// Token: 0x02003FFB RID: 16379
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node8 : Condition
	{
		// Token: 0x0601675B RID: 91995 RVA: 0x006CC0F7 File Offset: 0x006CA4F7
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601675C RID: 91996 RVA: 0x006CC12C File Offset: 0x006CA52C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFAA RID: 65450
		private int opl_p0;

		// Token: 0x0400FFAB RID: 65451
		private int opl_p1;

		// Token: 0x0400FFAC RID: 65452
		private int opl_p2;

		// Token: 0x0400FFAD RID: 65453
		private int opl_p3;
	}
}
