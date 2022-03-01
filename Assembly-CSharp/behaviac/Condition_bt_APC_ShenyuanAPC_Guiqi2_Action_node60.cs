using System;

namespace behaviac
{
	// Token: 0x02001E52 RID: 7762
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node60 : Condition
	{
		// Token: 0x06012651 RID: 75345 RVA: 0x00560359 File Offset: 0x0055E759
		public Condition_bt_APC_ShenyuanAPC_Guiqi2_Action_node60()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012652 RID: 75346 RVA: 0x0056036C File Offset: 0x0055E76C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C03A RID: 49210
		private float opl_p0;
	}
}
