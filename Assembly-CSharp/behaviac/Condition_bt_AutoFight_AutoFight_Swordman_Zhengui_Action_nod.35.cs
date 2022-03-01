using System;

namespace behaviac
{
	// Token: 0x020029AB RID: 10667
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node108 : Condition
	{
		// Token: 0x06013C8A RID: 81034 RVA: 0x005EAB92 File Offset: 0x005E8F92
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node108()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013C8B RID: 81035 RVA: 0x005EABA8 File Offset: 0x005E8FA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6F5 RID: 55029
		private float opl_p0;
	}
}
