using System;

namespace behaviac
{
	// Token: 0x020025F0 RID: 9712
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node47 : Condition
	{
		// Token: 0x06013527 RID: 79143 RVA: 0x005BE379 File Offset: 0x005BC779
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node47()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013528 RID: 79144 RVA: 0x005BE38C File Offset: 0x005BC78C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF6F RID: 53103
		private float opl_p0;
	}
}
