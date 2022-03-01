using System;

namespace behaviac
{
	// Token: 0x020021C2 RID: 8642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node42 : Condition
	{
		// Token: 0x06012D13 RID: 77075 RVA: 0x005890FE File Offset: 0x005874FE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node42()
		{
			this.opl_p0 = 0.69f;
		}

		// Token: 0x06012D14 RID: 77076 RVA: 0x00589114 File Offset: 0x00587514
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C706 RID: 50950
		private float opl_p0;
	}
}
