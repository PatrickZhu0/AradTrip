using System;

namespace behaviac
{
	// Token: 0x020040C8 RID: 16584
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node8 : Condition
	{
		// Token: 0x060168E7 RID: 92391 RVA: 0x006D4A2F File Offset: 0x006D2E2F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Zhaohuan_tongyong_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060168E8 RID: 92392 RVA: 0x006D4A64 File Offset: 0x006D2E64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401012C RID: 65836
		private int opl_p0;

		// Token: 0x0401012D RID: 65837
		private int opl_p1;

		// Token: 0x0401012E RID: 65838
		private int opl_p2;

		// Token: 0x0401012F RID: 65839
		private int opl_p3;
	}
}
