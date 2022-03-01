using System;

namespace behaviac
{
	// Token: 0x020021F6 RID: 8694
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node27 : Condition
	{
		// Token: 0x06012D79 RID: 77177 RVA: 0x0058BD02 File Offset: 0x0058A102
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node27()
		{
			this.opl_p0 = 0.68f;
		}

		// Token: 0x06012D7A RID: 77178 RVA: 0x0058BD18 File Offset: 0x0058A118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C76C RID: 51052
		private float opl_p0;
	}
}
