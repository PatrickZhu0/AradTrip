using System;

namespace behaviac
{
	// Token: 0x020021B6 RID: 8630
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node27 : Condition
	{
		// Token: 0x06012CFB RID: 77051 RVA: 0x00588B1E File Offset: 0x00586F1E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node27()
		{
			this.opl_p0 = 0.68f;
		}

		// Token: 0x06012CFC RID: 77052 RVA: 0x00588B34 File Offset: 0x00586F34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6EE RID: 50926
		private float opl_p0;
	}
}
