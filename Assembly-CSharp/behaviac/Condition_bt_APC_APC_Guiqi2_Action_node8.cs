using System;

namespace behaviac
{
	// Token: 0x02001D12 RID: 7442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node8 : Condition
	{
		// Token: 0x060123E7 RID: 74727 RVA: 0x005517E9 File Offset: 0x0054FBE9
		public Condition_bt_APC_APC_Guiqi2_Action_node8()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060123E8 RID: 74728 RVA: 0x00551808 File Offset: 0x0054FC08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDDB RID: 48603
		private BE_Target opl_p0;

		// Token: 0x0400BDDC RID: 48604
		private BE_Equal opl_p1;

		// Token: 0x0400BDDD RID: 48605
		private BE_State opl_p2;
	}
}
