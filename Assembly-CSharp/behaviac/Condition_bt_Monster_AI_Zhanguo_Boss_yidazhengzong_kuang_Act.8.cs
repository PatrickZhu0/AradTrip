using System;

namespace behaviac
{
	// Token: 0x02003EAD RID: 16045
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node8 : Condition
	{
		// Token: 0x060164D8 RID: 91352 RVA: 0x006BEA7A File Offset: 0x006BCE7A
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node8()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164D9 RID: 91353 RVA: 0x006BEAB0 File Offset: 0x006BCEB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD0B RID: 64779
		private int opl_p0;

		// Token: 0x0400FD0C RID: 64780
		private int opl_p1;

		// Token: 0x0400FD0D RID: 64781
		private int opl_p2;

		// Token: 0x0400FD0E RID: 64782
		private int opl_p3;
	}
}
