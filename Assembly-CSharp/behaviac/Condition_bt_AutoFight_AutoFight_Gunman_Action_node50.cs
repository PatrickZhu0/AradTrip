using System;

namespace behaviac
{
	// Token: 0x0200258D RID: 9613
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node50 : Condition
	{
		// Token: 0x06013462 RID: 78946 RVA: 0x005BAAD6 File Offset: 0x005B8ED6
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node50()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013463 RID: 78947 RVA: 0x005BAAEC File Offset: 0x005B8EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE8C RID: 52876
		private float opl_p0;
	}
}
