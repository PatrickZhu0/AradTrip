using System;

namespace behaviac
{
	// Token: 0x0200257A RID: 9594
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node26 : Condition
	{
		// Token: 0x0601343C RID: 78908 RVA: 0x005BA186 File Offset: 0x005B8586
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node26()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601343D RID: 78909 RVA: 0x005BA19C File Offset: 0x005B859C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE65 RID: 52837
		private float opl_p0;
	}
}
