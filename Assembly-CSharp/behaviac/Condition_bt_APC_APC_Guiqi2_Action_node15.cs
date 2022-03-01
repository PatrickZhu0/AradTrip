using System;

namespace behaviac
{
	// Token: 0x02001D19 RID: 7449
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node15 : Condition
	{
		// Token: 0x060123F5 RID: 74741 RVA: 0x00551DA2 File Offset: 0x005501A2
		public Condition_bt_APC_APC_Guiqi2_Action_node15()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060123F6 RID: 74742 RVA: 0x00551DB8 File Offset: 0x005501B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDE6 RID: 48614
		private float opl_p0;
	}
}
