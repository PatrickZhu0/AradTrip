using System;

namespace behaviac
{
	// Token: 0x02001E94 RID: 7828
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node64 : Condition
	{
		// Token: 0x060126D2 RID: 75474 RVA: 0x005637AE File Offset: 0x00561BAE
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node64()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x060126D3 RID: 75475 RVA: 0x005637E4 File Offset: 0x00561BE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0BF RID: 49343
		private int opl_p0;

		// Token: 0x0400C0C0 RID: 49344
		private int opl_p1;

		// Token: 0x0400C0C1 RID: 49345
		private int opl_p2;

		// Token: 0x0400C0C2 RID: 49346
		private int opl_p3;
	}
}
