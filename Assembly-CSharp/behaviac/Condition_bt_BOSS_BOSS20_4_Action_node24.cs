using System;

namespace behaviac
{
	// Token: 0x020029F4 RID: 10740
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node24 : Condition
	{
		// Token: 0x06013D1B RID: 81179 RVA: 0x005EE765 File Offset: 0x005ECB65
		public Condition_bt_BOSS_BOSS20_4_Action_node24()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013D1C RID: 81180 RVA: 0x005EE778 File Offset: 0x005ECB78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D790 RID: 55184
		private float opl_p0;
	}
}
