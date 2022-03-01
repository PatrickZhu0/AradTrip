using System;

namespace behaviac
{
	// Token: 0x02001E1C RID: 7708
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node21 : Condition
	{
		// Token: 0x060125E9 RID: 75241 RVA: 0x0055DB72 File Offset: 0x0055BF72
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node21()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x060125EA RID: 75242 RVA: 0x0055DBA8 File Offset: 0x0055BFA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFD2 RID: 49106
		private int opl_p0;

		// Token: 0x0400BFD3 RID: 49107
		private int opl_p1;

		// Token: 0x0400BFD4 RID: 49108
		private int opl_p2;

		// Token: 0x0400BFD5 RID: 49109
		private int opl_p3;
	}
}
