using System;

namespace behaviac
{
	// Token: 0x020024D0 RID: 9424
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node94 : Condition
	{
		// Token: 0x060132EA RID: 78570 RVA: 0x005B227E File Offset: 0x005B067E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node94()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060132EB RID: 78571 RVA: 0x005B2294 File Offset: 0x005B0694
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD07 RID: 52487
		private float opl_p0;
	}
}
