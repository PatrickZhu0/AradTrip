using System;

namespace behaviac
{
	// Token: 0x020025EA RID: 9706
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node70 : Condition
	{
		// Token: 0x0601351B RID: 79131 RVA: 0x005BDFF9 File Offset: 0x005BC3F9
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node70()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601351C RID: 79132 RVA: 0x005BE00C File Offset: 0x005BC40C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF61 RID: 53089
		private float opl_p0;
	}
}
