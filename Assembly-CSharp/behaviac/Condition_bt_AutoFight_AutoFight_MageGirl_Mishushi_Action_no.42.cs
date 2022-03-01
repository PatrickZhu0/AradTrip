using System;

namespace behaviac
{
	// Token: 0x020026E7 RID: 9959
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node44 : Condition
	{
		// Token: 0x06013711 RID: 79633 RVA: 0x005C9D8D File Offset: 0x005C818D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node44()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013712 RID: 79634 RVA: 0x005C9DA0 File Offset: 0x005C81A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D169 RID: 53609
		private float opl_p0;
	}
}
