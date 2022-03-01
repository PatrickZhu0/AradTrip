using System;

namespace behaviac
{
	// Token: 0x0200213E RID: 8510
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node27 : Condition
	{
		// Token: 0x06012C0E RID: 76814 RVA: 0x005830CA File Offset: 0x005814CA
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node27()
		{
			this.opl_p0 = 0.27f;
		}

		// Token: 0x06012C0F RID: 76815 RVA: 0x005830E0 File Offset: 0x005814E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C601 RID: 50689
		private float opl_p0;
	}
}
