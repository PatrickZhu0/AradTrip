using System;

namespace behaviac
{
	// Token: 0x020021C6 RID: 8646
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node47 : Condition
	{
		// Token: 0x06012D1B RID: 77083 RVA: 0x0058929A File Offset: 0x0058769A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node47()
		{
			this.opl_p0 = 0.75f;
		}

		// Token: 0x06012D1C RID: 77084 RVA: 0x005892B0 File Offset: 0x005876B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C70E RID: 50958
		private float opl_p0;
	}
}
