using System;

namespace behaviac
{
	// Token: 0x020021F2 RID: 8690
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node22 : Condition
	{
		// Token: 0x06012D71 RID: 77169 RVA: 0x0058BB66 File Offset: 0x00589F66
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node22()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012D72 RID: 77170 RVA: 0x0058BB7C File Offset: 0x00589F7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C764 RID: 51044
		private float opl_p0;
	}
}
