using System;

namespace behaviac
{
	// Token: 0x0200266E RID: 9838
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node36 : Condition
	{
		// Token: 0x06013621 RID: 79393 RVA: 0x005C49A9 File Offset: 0x005C2DA9
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node36()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013622 RID: 79394 RVA: 0x005C49BC File Offset: 0x005C2DBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D075 RID: 53365
		private float opl_p0;
	}
}
