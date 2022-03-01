using System;

namespace behaviac
{
	// Token: 0x02002729 RID: 10025
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node59 : Condition
	{
		// Token: 0x06013794 RID: 79764 RVA: 0x005CD0E9 File Offset: 0x005CB4E9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node59()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013795 RID: 79765 RVA: 0x005CD0FC File Offset: 0x005CB4FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1EF RID: 53743
		private float opl_p0;
	}
}
