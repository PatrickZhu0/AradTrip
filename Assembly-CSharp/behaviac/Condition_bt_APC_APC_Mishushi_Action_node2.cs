using System;

namespace behaviac
{
	// Token: 0x02001DBB RID: 7611
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node2 : Condition
	{
		// Token: 0x0601252E RID: 75054 RVA: 0x00559BB3 File Offset: 0x00557FB3
		public Condition_bt_APC_APC_Mishushi_Action_node2()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 3;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601252F RID: 75055 RVA: 0x00559BE4 File Offset: 0x00557FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF1F RID: 48927
		private int opl_p0;

		// Token: 0x0400BF20 RID: 48928
		private int opl_p1;

		// Token: 0x0400BF21 RID: 48929
		private int opl_p2;

		// Token: 0x0400BF22 RID: 48930
		private int opl_p3;
	}
}
