using System;

namespace behaviac
{
	// Token: 0x02001E15 RID: 7701
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node4 : Condition
	{
		// Token: 0x060125DB RID: 75227 RVA: 0x0055D86F File Offset: 0x0055BC6F
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060125DC RID: 75228 RVA: 0x0055D88C File Offset: 0x0055BC8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFC4 RID: 49092
		private BE_Target opl_p0;

		// Token: 0x0400BFC5 RID: 49093
		private BE_Equal opl_p1;

		// Token: 0x0400BFC6 RID: 49094
		private BE_State opl_p2;
	}
}
