using System;

namespace behaviac
{
	// Token: 0x020025AE RID: 9646
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node56 : Condition
	{
		// Token: 0x060134A3 RID: 79011 RVA: 0x005BC6E1 File Offset: 0x005BAAE1
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node56()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x060134A4 RID: 79012 RVA: 0x005BC6F4 File Offset: 0x005BAAF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CED9 RID: 52953
		private float opl_p0;
	}
}
