using System;

namespace behaviac
{
	// Token: 0x02002741 RID: 10049
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node32 : Condition
	{
		// Token: 0x060137C4 RID: 79812 RVA: 0x005CDB21 File Offset: 0x005CBF21
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node32()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060137C5 RID: 79813 RVA: 0x005CDB34 File Offset: 0x005CBF34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D21F RID: 53791
		private float opl_p0;
	}
}
