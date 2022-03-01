using System;

namespace behaviac
{
	// Token: 0x020021EE RID: 8686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node17 : Condition
	{
		// Token: 0x06012D69 RID: 77161 RVA: 0x0058B91B File Offset: 0x00589D1B
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node17()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012D6A RID: 77162 RVA: 0x0058B930 File Offset: 0x00589D30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C75C RID: 51036
		private float opl_p0;
	}
}
