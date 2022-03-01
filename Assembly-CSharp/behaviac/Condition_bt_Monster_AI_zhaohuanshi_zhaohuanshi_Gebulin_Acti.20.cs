using System;

namespace behaviac
{
	// Token: 0x02003FA6 RID: 16294
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node36 : Condition
	{
		// Token: 0x060166B6 RID: 91830 RVA: 0x006C8117 File Offset: 0x006C6517
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node36()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060166B7 RID: 91831 RVA: 0x006C814C File Offset: 0x006C654C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF08 RID: 65288
		private int opl_p0;

		// Token: 0x0400FF09 RID: 65289
		private int opl_p1;

		// Token: 0x0400FF0A RID: 65290
		private int opl_p2;

		// Token: 0x0400FF0B RID: 65291
		private int opl_p3;
	}
}
