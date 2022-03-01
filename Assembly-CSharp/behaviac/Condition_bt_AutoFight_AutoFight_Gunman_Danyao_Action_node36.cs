using System;

namespace behaviac
{
	// Token: 0x020025A6 RID: 9638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node36 : Condition
	{
		// Token: 0x06013493 RID: 78995 RVA: 0x005BC379 File Offset: 0x005BA779
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node36()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06013494 RID: 78996 RVA: 0x005BC38C File Offset: 0x005BA78C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEC9 RID: 52937
		private float opl_p0;
	}
}
