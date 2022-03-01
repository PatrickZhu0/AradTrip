using System;

namespace behaviac
{
	// Token: 0x0200235F RID: 9055
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node60 : Condition
	{
		// Token: 0x0601302B RID: 77867 RVA: 0x0059F16E File Offset: 0x0059D56E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node60()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601302C RID: 77868 RVA: 0x0059F184 File Offset: 0x0059D584
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA43 RID: 51779
		private float opl_p0;
	}
}
