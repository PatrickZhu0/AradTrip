using System;

namespace behaviac
{
	// Token: 0x0200409C RID: 16540
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node15 : Condition
	{
		// Token: 0x06016893 RID: 92307 RVA: 0x006D2C13 File Offset: 0x006D1013
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06016894 RID: 92308 RVA: 0x006D2C48 File Offset: 0x006D1048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100DB RID: 65755
		private int opl_p0;

		// Token: 0x040100DC RID: 65756
		private int opl_p1;

		// Token: 0x040100DD RID: 65757
		private int opl_p2;

		// Token: 0x040100DE RID: 65758
		private int opl_p3;
	}
}
