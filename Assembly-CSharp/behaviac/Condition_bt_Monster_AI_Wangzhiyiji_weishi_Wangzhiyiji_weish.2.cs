using System;

namespace behaviac
{
	// Token: 0x02003DA9 RID: 15785
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node5 : Condition
	{
		// Token: 0x060162E3 RID: 90851 RVA: 0x006B4A6D File Offset: 0x006B2E6D
		public Condition_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node5()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060162E4 RID: 90852 RVA: 0x006B4A80 File Offset: 0x006B2E80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB2C RID: 64300
		private float opl_p0;
	}
}
