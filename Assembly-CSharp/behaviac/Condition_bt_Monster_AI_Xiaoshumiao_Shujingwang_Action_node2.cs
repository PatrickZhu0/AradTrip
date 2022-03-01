using System;

namespace behaviac
{
	// Token: 0x02003E05 RID: 15877
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node27 : Condition
	{
		// Token: 0x06016393 RID: 91027 RVA: 0x006B8049 File Offset: 0x006B6449
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node27()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06016394 RID: 91028 RVA: 0x006B8080 File Offset: 0x006B6480
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBF9 RID: 64505
		private int opl_p0;

		// Token: 0x0400FBFA RID: 64506
		private int opl_p1;

		// Token: 0x0400FBFB RID: 64507
		private int opl_p2;

		// Token: 0x0400FBFC RID: 64508
		private int opl_p3;
	}
}
