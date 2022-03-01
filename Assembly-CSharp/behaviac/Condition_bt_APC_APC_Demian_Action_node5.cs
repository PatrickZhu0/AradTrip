using System;

namespace behaviac
{
	// Token: 0x02001CFE RID: 7422
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node5 : Condition
	{
		// Token: 0x060123C1 RID: 74689 RVA: 0x005507C4 File Offset: 0x0054EBC4
		public Condition_bt_APC_APC_Demian_Action_node5()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060123C2 RID: 74690 RVA: 0x005507E4 File Offset: 0x0054EBE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDB7 RID: 48567
		private BE_Target opl_p0;

		// Token: 0x0400BDB8 RID: 48568
		private BE_Equal opl_p1;

		// Token: 0x0400BDB9 RID: 48569
		private BE_State opl_p2;
	}
}
