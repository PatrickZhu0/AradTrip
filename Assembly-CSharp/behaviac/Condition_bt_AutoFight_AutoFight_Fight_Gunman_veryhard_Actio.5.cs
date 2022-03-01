using System;

namespace behaviac
{
	// Token: 0x020021EA RID: 8682
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node12 : Condition
	{
		// Token: 0x06012D61 RID: 77153 RVA: 0x0058B676 File Offset: 0x00589A76
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node12()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012D62 RID: 77154 RVA: 0x0058B68C File Offset: 0x00589A8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C754 RID: 51028
		private float opl_p0;
	}
}
