using System;

namespace behaviac
{
	// Token: 0x0200401F RID: 16415
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node8 : Condition
	{
		// Token: 0x060167A0 RID: 92064 RVA: 0x006CD853 File Offset: 0x006CBC53
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node8()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060167A1 RID: 92065 RVA: 0x006CD888 File Offset: 0x006CBC88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFED RID: 65517
		private int opl_p0;

		// Token: 0x0400FFEE RID: 65518
		private int opl_p1;

		// Token: 0x0400FFEF RID: 65519
		private int opl_p2;

		// Token: 0x0400FFF0 RID: 65520
		private int opl_p3;
	}
}
