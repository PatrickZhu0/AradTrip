using System;

namespace behaviac
{
	// Token: 0x020024C9 RID: 9417
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node84 : Condition
	{
		// Token: 0x060132DC RID: 78556 RVA: 0x005B1FA7 File Offset: 0x005B03A7
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node84()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060132DD RID: 78557 RVA: 0x005B1FBC File Offset: 0x005B03BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCFB RID: 52475
		private float opl_p0;
	}
}
