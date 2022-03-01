using System;

namespace behaviac
{
	// Token: 0x02003468 RID: 13416
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node0 : Condition
	{
		// Token: 0x0601511B RID: 86299 RVA: 0x006594FF File Offset: 0x006578FF
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node0()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x0601511C RID: 86300 RVA: 0x00659520 File Offset: 0x00657920
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA1B RID: 59931
		private BE_Target opl_p0;

		// Token: 0x0400EA1C RID: 59932
		private BE_Equal opl_p1;

		// Token: 0x0400EA1D RID: 59933
		private int opl_p2;
	}
}
