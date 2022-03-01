using System;

namespace behaviac
{
	// Token: 0x02001DFE RID: 7678
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node12 : Condition
	{
		// Token: 0x060125AF RID: 75183 RVA: 0x0055C687 File Offset: 0x0055AA87
		public Condition_bt_APC_APC_Swordman_test_Action_node12()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060125B0 RID: 75184 RVA: 0x0055C69C File Offset: 0x0055AA9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFA0 RID: 49056
		private float opl_p0;
	}
}
