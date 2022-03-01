using System;

namespace behaviac
{
	// Token: 0x02001DFD RID: 7677
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node9 : Condition
	{
		// Token: 0x060125AD RID: 75181 RVA: 0x0055C628 File Offset: 0x0055AA28
		public Condition_bt_APC_APC_Swordman_test_Action_node9()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060125AE RID: 75182 RVA: 0x0055C648 File Offset: 0x0055AA48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF9D RID: 49053
		private BE_Target opl_p0;

		// Token: 0x0400BF9E RID: 49054
		private BE_Equal opl_p1;

		// Token: 0x0400BF9F RID: 49055
		private BE_State opl_p2;
	}
}
