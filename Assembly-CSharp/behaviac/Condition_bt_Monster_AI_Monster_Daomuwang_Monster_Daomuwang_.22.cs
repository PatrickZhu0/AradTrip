using System;

namespace behaviac
{
	// Token: 0x02003639 RID: 13881
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node2 : Condition
	{
		// Token: 0x06015495 RID: 87189 RVA: 0x0066B212 File Offset: 0x00669612
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06015496 RID: 87190 RVA: 0x0066B248 File Offset: 0x00669648
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE4D RID: 61005
		private int opl_p0;

		// Token: 0x0400EE4E RID: 61006
		private int opl_p1;

		// Token: 0x0400EE4F RID: 61007
		private int opl_p2;

		// Token: 0x0400EE50 RID: 61008
		private int opl_p3;
	}
}
