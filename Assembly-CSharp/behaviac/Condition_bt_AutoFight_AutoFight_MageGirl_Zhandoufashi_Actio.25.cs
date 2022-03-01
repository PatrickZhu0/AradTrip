using System;

namespace behaviac
{
	// Token: 0x02002721 RID: 10017
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node49 : Condition
	{
		// Token: 0x06013784 RID: 79748 RVA: 0x005CCD81 File Offset: 0x005CB181
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node49()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013785 RID: 79749 RVA: 0x005CCD94 File Offset: 0x005CB194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1DF RID: 53727
		private float opl_p0;
	}
}
